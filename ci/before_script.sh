#!/usr/bin/env bash

set -e
set -x
mkdir -p /root/.cache/unity3d
mkdir -p /root/.local/share/unity3d/Unity/
set +x
#echo 'Writing $UNITY_LICENSE_CONTENT to license file /root/.local/share/unity3d/Unity/Unity_lic.ulf'
#echo "$UNITY_LICENSE_CONTENT" | base64 --decode | tr -d '\r' > /root/.local/share/unity3d/Unity/Unity_lic.ulf
#echo "${UNITY_LICENSE_CONTENT}" | tr -d '\r' > /root/.local/share/unity3d/Unity/Unity_lic.ulf

openssl aes-256-cbc -md sha512 -pbkdf2 -d -in .circleci/unity3d.x.ulf-enc -k ${UNITY_CIPHER} >> .circleci/unity3d.x.ulf

${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' unity-editor} \\
  -quit \\
  -batchmode \\
  -nographics \\
  -silent-crashes \\
  -manualLicenseFile $(pwd)/.circleci/unity3d.x.ulf 