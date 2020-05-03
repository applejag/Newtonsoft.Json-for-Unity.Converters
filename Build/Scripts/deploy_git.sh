#!/bin/bash

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${VERSION_UPM:?}
: ${VERSION_UPM_NO_SUFFIX:?}
: ${VERSION_SUFFIX:?}
: ${REPO_FOLDER:?}
: ${PACKAGE_FOLDER:?}

if git tag --list | egrep -q "^$VERSION_UPM$"
then
    echo "Tag $VERSION_UPM already existed. Skipping the deployment"
    exit 0
fi

echo ">> Backing up package at /package"
mkdir -pv /package
cp -fv $REPO_FOLDER/CHANGELOG.md $PACKAGE_FOLDER/.
cp -r $PACKAGE_FOLDER/. /package/.
echo

echo ">> Checking out upm branch"
git checkout upm --force
echo

echo ">> Replacing package"
git rm -r $REPO_FOLDER/*
mv /package/{*,.*} $REPO_FOLDER/.
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

Created by CircleCI job
Build #$CIRCLE_BUILD_NUM
$CIRCLE_BUILD_URL"
    echo "Created commit '$(git log -n1 --format="%s")'"
fi
echo

git tag $VERSION_UPM -m "Json.NET Unity Converters $VERSION_UPM

Created by CircleCI job
Build #$CIRCLE_BUILD_NUM
$CIRCLE_BUILD_URL"

echo "Created tag '$(git tag -l $VERSION_UPM -n1)'"
git push --follow-tags --dry-run
echo
echo "Successfully pushed"
