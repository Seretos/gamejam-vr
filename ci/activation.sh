#!/usr/bin/env bash

set -e
set -x

xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' \
unity-editor \
-logFile /dev/stdout \
-batchmode \
-nographics \
-username "$UNITY_USERNAME" -password "$UNITY_PASSWORD"