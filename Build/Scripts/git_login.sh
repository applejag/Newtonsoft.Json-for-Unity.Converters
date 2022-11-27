#!/usr/bin/env bash
# Script taken from https://github.com/zifro-playground/ui
# Copyright Zifro © 2019

# Set error flags
set -o nounset
set -o errexit
set -o pipefail

: ${GIT_USER_NAME:?}
: ${GIT_USER_EMAIL:?}

# Git settings
git config --global user.name "$GIT_USER_NAME"
echo "Set git username to: '$GIT_USER_NAME'"
git config --global user.email "$GIT_USER_EMAIL"
echo "Set git user email to: '$GIT_USER_EMAIL'"

if [ "${GIT_GPG_ID:-}" != "" ]; then
    : ${GIT_GPG_SEC_B64:?"GPG key content must be set if '\$GIT_GPG_ID' is set"}

    # Load GPG keys
    GIT_GPG_SEC=$(base64 -di - <<< "$GIT_GPG_SEC_B64")
    gpg --import - <<< "$GIT_GPG_SEC"

    git config --global user.signingKey "$GIT_GPG_ID"
    echo "Set git gpg key to: '$GIT_GPG_ID'"
    git config --global commit.gpgSign true
    echo "Set git commit signing to: true"
    git config --global tag.forceSignAnnotated true
    echo "Set git tag signing to: true"

    mkdir -p ~/.gnupg
    echo 'no-tty' >> ~/.gnupg/gpg.conf
else
    echo "Not loading GPG key; \$GIT_GPG_ID was empty"
fi
