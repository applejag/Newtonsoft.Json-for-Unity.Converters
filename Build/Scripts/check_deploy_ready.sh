#!/bin/bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${VERSION_UPM:?"Need the version to be checked"}
: ${VERSION_UPM_NO_SUFFIX:?"Need the version of Newtonsoft.Json.UnityConverters (without suffix) to be checked"}

OK=1

echo

if egrep -q "^## ${VERSION_UPM_NO_SUFFIX//\./\\.}$" CHANGELOG.md
then
    echo "> Changelog has been updated, all ok!"
else
    echo
    echo "[!] Changelog in CHANGELOG.md is missing line '## $VERSION_UPM_NO_SUFFIX'."
    echo "[!] Make sure to update the CHANGELOG.md"
    OK=0
fi

echo

if [ $OK != 1 ]
then
    echo "At least one check failed. Aborting!"
    exit 1
fi

echo "Nice work! Happy deploying!"
