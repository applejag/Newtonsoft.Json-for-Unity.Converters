#!/bin/bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

jsonFile="${1?Path to JSON required.}"
output="${2:-FULL}"

error() {
    >&2 echo "$0: $@"
}

if ! [ -x "$(command -v jq)" ]
then
    error "Error: jq is not installed"
    exit 1
fi

if ! [ -f "$jsonFile" ]
then
    error "Error: file not found '$jsonFile'"
    exit 2
fi

jq2() {
    result="$(jq "$@")"
    if [ -z "$result" ]
    then
        error "Error: No output"
        exit 4
    else
        echo "$result"
    fi
}

case "$output" in
FILE)
    VERSION="$(jq2 -er '(.JsonNET // 0|tostring) + "." + (.Minor // 0|tostring) + "." + (.Patch // 0|tostring)' "$jsonFile")"
    
    MINUTES_1970_TO_2019=$((25771680))

    TIMESTAMP_SECONDS=$(date +%s)
    TIMESTAMP_MINUTES_SINCE_2019=$((TIMESTAMP_SECONDS/60 - MINUTES_1970_TO_2019))

    # To convert back to timestamp do:
    # TIMESTAMP_SECONDS = (REVISION + 25771680) * 60

    REVISION=TIMESTAMP_MINUTES_SINCE_2019

    echo "$VERSION.$REVISION"
    ;;
UPM)
    VERSION="$(jq2 -er '(.JsonNET // 0|tostring) + "." + (.Minor // 0|tostring) + "." + (.Patch // 0|tostring)' "$jsonFile")"
    SUFFIX="$(jq2 -er '.Suffix // empty' "$jsonFile")"

    if [ -z "$SUFFIX" ]
    then
        echo "$VERSION"
    else
        echo "$VERSION-$SUFFIX"
    fi
    ;;
JSON_NET)
    jq2 -er '(.JsonNET // 0|tostring) + ".x.x"' "$jsonFile"
    ;;
CONVERTERS)
    VERSION="$(jq2 -er '"x." + (.Minor // 0|tostring) + "." + (.Patch // 0|tostring)' "$jsonFile")"
    SUFFIX="$(jq2 -er '.Suffix // empty' "$jsonFile")"

    if [ -z "$SUFFIX" ]
    then
        echo "$VERSION"
    else
        echo "$VERSION-$SUFFIX"
    fi
    ;;
ASSEMBLY)
    jq2 -er '(.JsonNET // 0|tostring) + ".0.0.0"' "$jsonFile"
    ;;
SUFFIX)
    jq2 -er '.Suffix // empty' "$jsonFile"
    ;;
*)
    error "Error: Unknown output type '$output'
    Possible values: FILE, UPM, JSON_NET, CONVERTERS, ASSEMBLY, SUFFIX"
    exit 3
    ;;
esac
