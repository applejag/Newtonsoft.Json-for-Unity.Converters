#!/usr/bin/env bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${VERSION_UPM:?}
: ${VERSION_UPM_NO_SUFFIX:?}
: ${REPO_FOLDER:?}
: ${PACKAGE_FOLDER:?}

TAG_UPM="$VERSION_UPM"

tag_and_push() {
    local tagName="$1"
    local tagMessage="$2"

    git tag $tagName -m "$tagMessage"

    echo "Created tag: '$(git tag -l $tagName -n1))'"

    if [ "${VERSION_AUTO_DEPLOY_LIVE_RUN:-}" == "true" ]
    then
        git push --follow-tags
    else
        echo "RUNNING GIT PUSH DRY-RUN"
        git push --follow-tags --dry-run
        echo "RUNNING GIT PUSH DRY-RUN"
    fi
    echo
    echo "Successfully pushed"
}

#-------------------------------------------------------------------------------

if git tag --list | egrep -q "^$TAG_UPM$"
then
    echo "Tag $TAG_UPM already existed. Skipping the deployment to upm branch"
else

    echo ">> Backing up package at /package"
    mkdir -pv /package
    cp -fv \
        $REPO_FOLDER/CHANGELOG.md \
        $REPO_FOLDER/THIRD-PARTY-NOTICES.md \
        $PACKAGE_FOLDER/.

    cp -r $PACKAGE_FOLDER/. /package/.
    echo

    echo ">> Checking out upm branch"
    git checkout upm --force
    echo

    echo ">> Replacing package"
    shopt -s dotglob
    GLOBIGNORE='.git' git rm \* -rf --ignore-unmatch
    git clean -dfx
    mv /package/* $REPO_FOLDER/.
    shopt -u dotglob
    git add .
    echo

    echo ">> Status"
    git status --short
    STATUS="$(git status --short)"
    echo

    if [ -z "$STATUS" ]
    then
        echo "No changes to package in UPM branch. Will not create a new commit."
    else
        git commit -m "Json.NET Unity Converters $VERSION_UPM

Based on commit $CIRCLE_SHA1

Created by CircleCI job
Build #$CIRCLE_BUILD_NUM
$CIRCLE_BUILD_URL"
        echo "Created commit '$(git log -n1 --format="%s")'"
    fi
    echo

    tag_and_push $TAG_UPM "Json.NET Unity Converters $VERSION_UPM

Based on commit $CIRCLE_SHA1

Created by CircleCI job
Build #$CIRCLE_BUILD_NUM
$CIRCLE_BUILD_URL"
fi
