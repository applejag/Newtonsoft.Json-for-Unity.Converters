#!/bin/bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${VERSION_UPM:?"Need the version to be checked"}
: ${VERSION_UPM_NO_SUFFIX:?"Need the version of Newtonsoft.Json.UnityConverters (without suffix) to be checked"}
: ${NPM_REGISTRY:?"Need the NPM registry to be checked against"}

OK=1

if [ "$(npm search jillejr.newtonsoft.json-for-unity.converters)" == 'No matches found for "jillejr.newtonsoft.json-for-unity.converters"' ]
then
    echo "> Package jillejr.newtonsoft.json-for-unity.converters does not exist on the registry and is available for publishing, all ok!"
elif [ -z "$(npm view jillejr.newtonsoft.json-for-unity.converters@$VERSION_UPM versions)" ]
then
    echo "> Package jillejr.newtonsoft.json-for-unity.converters version $VERSION_UPM does not exist on the registry and is available for publishing, all ok!"
else
    echo
    echo "[!] Package version $VERSION_UPM already existed on $NPM_REGISTRY"
    echo "[!] Make sure to update the /Build/version.json"
    OK=0
fi

echo

if git tag --list | egrep -q "^$VERSION_UPM$"
then
    echo
    echo "[!] Tag $VERSION_UPM already existed."
    echo "[!] Make sure to update the /Build/version.json"
    OK=0
else
    echo "> Tag $VERSION_UPM is available for publishing, all ok!"
fi

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
