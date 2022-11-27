#!/usr/bin/env bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

jsonFile="${1?Path to JSON required.}"
output="${2:-UPM}"

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
UPM)
    VERSION="$(jq2 -er '(.Major // 0|tostring) + "." + (.Minor // 0|tostring) + "." + (.Patch // 0|tostring)' "$jsonFile")"
    SUFFIX="$(jq -er '.Suffix // empty' "$jsonFile")"

    if [ -z "$SUFFIX" ]
    then
        echo "$VERSION"
    else
        echo "$VERSION-$SUFFIX"
    fi
    ;;
UPM_NO_SUFFIX)
    jq2 -er '(.Major // 0|tostring) + "." + (.Minor // 0|tostring) + "." + (.Patch // 0|tostring)' "$jsonFile"
    ;;
SUFFIX)
    jq2 -er '.Suffix // empty' "$jsonFile"
    ;;
AUTO_DEPLOY_LIVE_RUN)
    jq2 -r '.AutoDeployLiveRun' "$jsonFile"
    ;;
*)
    error "Error: Unknown output type '$output'
    Possible values: UPM, UPM_NO_SUFFIX, SUFFIX, AUTO_DEPLOY_LIVE_RUN"
    exit 3
    ;;
esac
