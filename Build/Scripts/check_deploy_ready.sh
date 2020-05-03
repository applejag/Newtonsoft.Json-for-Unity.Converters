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

for ENV_VAR in "NPM_AUTH_TOKEN GIT_USER_EMAIL GIT_USER_NAME GIT_GPG_ID GIT_GPG_SEC_B64"
do
    if [ -z "${!ENV_VAR}" ]
    then
        echo "> Environment variable \$$ENV_VAR is set, all ok!"
    else
        echo
        echo "[!] Missing environment variable \$$ENV_VAR."
        OK=0
    fi

done

echo

if [ $OK != 1 ]
then
    echo "At least one check failed. Aborting!"
    exit 1
fi

echo "Nice work! Happy deploying!"
