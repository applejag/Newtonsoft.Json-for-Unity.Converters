#!/bin/bash

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
env VERSION_FILE "$($SCRIPTS/get_json_version.sh ./Build/version.json FILE)"
env VERSION_UPM "$($SCRIPTS/get_json_version.sh ./Build/version.json UPM)"
env VERSION_UPM_NO_SUFFIX "$($SCRIPTS/get_json_version.sh ./Build/version.json UPM_NO_SUFFIX)"
env VERSION_SUFFIX "$($SCRIPTS/get_json_version.sh ./Build/version.json SUFFIX)"
env VERSION_JSON_NET "$($SCRIPTS/get_json_version.sh ./Build/version.json JSON_NET)"
env VERSION_CONVERTERS "$($SCRIPTS/get_json_version.sh ./Build/version.json CONVERTERS)"
env VERSION_ASSEMBLY "$($SCRIPTS/get_json_version.sh ./Build/version.json ASSEMBLY)"
echo

# Example output of variables:
# VERSION_FILE='12.0.1.633183'
# VERSION_UPM='12.0.1-preview.1'
# VERSION_UPM_NO_SUFFIX='12.0.1'
# VERSION_SUFFIX='preview.1'
# VERSION_JSON_NET='12.x.x'
# VERSION_CONVERTERS='x.0.1-preview.1'
# VERSION_ASSEMBLY='12.0.0.0'

DESCRIPTION="This package contains converters to and from common Unity types. Types such as Vector2, Vector3, Matrix4x4, Quaternions, Color, and more.

This is Newtonsoft.Json.UnityConverters version $VERSION_CONVERTERS
Compatible with Newtonsoft.Json $VERSION_JSON_NET
Goes hand in hand with the jillejr.newtonsoft.json-for-unity

This package is licensed under The MIT License (MIT)

Copyright © 2019 Kalle Jillheden (jilleJr)
https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters

Copyright © 2007 ParentElement
https://github.com/ianmacgillivray/Json-NET-for-Unity

See full copyrights in LICENSE.md inside package"

echo ">>> UPDATING VERSION IN $(pwd)/Src/UnityConvertersPackage/package.json"
echo "BEFORE:"
echo ".version=$(jq ".version" Src/UnityConvertersPackage/package.json)"
echo "$(jq ".version=\"$VERSION_UPM\" | .description=\"$DESCRIPTION\"" Src/UnityConvertersPackage/package.json)" > Src/UnityConvertersPackage/package.json
echo "AFTER:"
echo ".version=$(jq ".version" Src/UnityConvertersPackage/package.json)"
