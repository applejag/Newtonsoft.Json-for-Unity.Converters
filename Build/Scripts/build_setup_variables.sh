#!/usr/bin/env bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail


env() {
    echo "export '$1=$2'" >> $BASH_ENV
    echo "$1='$2'"
    export "$1=$2"
}
echo ">>> OBTAINING VERSION FROM $(pwd)/Build/version.json"
env VERSION_UPM "$($SCRIPTS/get_json_version.sh ./Build/version.json UPM)"
env VERSION_UPM_NO_SUFFIX "$($SCRIPTS/get_json_version.sh ./Build/version.json UPM_NO_SUFFIX)"
env VERSION_SUFFIX "$($SCRIPTS/get_json_version.sh ./Build/version.json SUFFIX)"
env VERSION_AUTO_DEPLOY_LIVE_RUN "$($SCRIPTS/get_json_version.sh ./Build/version.json AUTO_DEPLOY_LIVE_RUN)"
echo

# Example output of variables:
# VERSION_UPM='12.0.1-preview.1'
# VERSION_UPM_NO_SUFFIX='12.0.1'
# VERSION_SUFFIX='preview.1'
# VERSION_AUTO_DEPLOY_LIVE_RUN='false'

DESCRIPTION="This package contains converters to and from common Unity types for Newtonsoft.Json. Types such as Vector2, Vector3, Matrix4x4, Quaternions, Color, even ScriptableObject, and more.

Goes hand in hand with the jillejr.newtonsoft.json-for-unity package.

This package is licensed under The MIT License (MIT)

Copyright © 2019 Kalle Jillheden (jilleJr)
https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters

Copyright © 2020 Wanzyee Studio
http://wanzyeestudio.blogspot.com/2017/03/jsonnet-converters.html

Copyright © 2007 ParentElement
https://github.com/ianmacgillivray/Json-NET-for-Unity

Copyright © 2017 .NET Foundation and Contributors
https://github.com/dotnet/runtime

See full copyrights in LICENSE.md inside package"

echo ">>> UPDATING VERSION IN $(pwd)/$PACKAGE_FOLDER/package.json"
echo "BEFORE:"
echo ".version=$(jq ".version" $PACKAGE_FOLDER/package.json)"
echo "$(jq ".version=\"$VERSION_UPM\" | .description=\"$DESCRIPTION\"" $PACKAGE_FOLDER/package.json)" > $PACKAGE_FOLDER/package.json
echo "AFTER:"
echo ".version=$(jq ".version" $PACKAGE_FOLDER/package.json)"
