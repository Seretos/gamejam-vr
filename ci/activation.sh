UNITY_VERSION=2020.3.21f1
IMAGE=unityci/editor # https://hub.docker.com/r/unityci/editor
IMAGE_VERSION=0.15 # https://github.com/game-ci/docker/releases
DOCKER_IMAGE=$IMAGE:$UNITY_VERSION-base-$IMAGE_VERSION

docker run -it --rm \
-e "UNITY_USERNAME=youremail" \
-e "UNITY_PASSWORD=yourpassword" \
-e "TEST_PLATFORM=linux" \
-e "WORKDIR=/root/project" \
-v "$(pwd):/root/project" \
$DOCKER_IMAGE \
bash