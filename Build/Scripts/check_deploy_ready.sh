#!/bin/bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${VERSION:?"Need the version to be checked"}
: ${VERSION_SUFFIX:?"Need the version suffix to be checked"}
: ${NPM_REGISTRY:?"Need the NPM registry to be checked against"}

OK=1

if [ "$(npm search jillejr.newtonsoft.json-for-unity.converters)" == 'No matches found for "jillejr.newtonsoft.json-for-unity.converters"' ]
then
    echo "> Package jillejr.newtonsoft.json-for-unity.converters does not exist on the registry and is available for publishing, all ok!"
elif [ -z "$(npm view jillejr.newtonsoft.json-for-unity.converters@$VERSION versions)" ]
then
    echo "> Package jillejr.newtonsoft.json-for-unity.converters version $VERSION does not exist on the registry and is available for publishing, all ok!"
else
    echo
    echo "[!] Package version $VERSION already existed on $NPM_REGISTRY"
    echo "[!] Make sure to update the /Build/version.json"
    OK=0
fi

echo

if git tag --list | egrep -q "^$VERSION$"
then
    echo
    echo "[!] Tag $VERSION already existed."
    echo "[!] Make sure to update the /Build/version.json"
    OK=0
else
    echo "> Tag $VERSION is available for publishing, all ok!"
fi

echo

if [ "$VERSION_SUFFIX" != "" ]
then
    echo "> Ignoring to check changelog since suffix is '$VERSION_SUFFIX', all ok!"
elif egrep -f CHANGELOG.md -q "^## $VERSION$"
then
    echo "> Changelog has been updated, all ok!"
else
    echo
    echo "[!] Changelog in CHANGELOG.md is missing line '## $VERSION'."
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
