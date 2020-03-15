
# Possible alterations of UNITY_VERSION argument, using example v1:
# v1-2019.2.11f1
# v1-2018.4.14f1
ARG UNITY_VERSION=2019.2.11f1
FROM applejag/newtonsoft.json-for-unity.package-unity-tester:v1-${UNITY_VERSION}

# IMAGE_VERSION should correspond to the image tag
ARG IMAGE_VERSION
ARG UNITY_VERSION=2019.2.11f1

ENV UNITY_VERTION=${UNITY_VERSION} \
    IMAGE_VERSION=${IMAGE_VERSION}

RUN \
    # Symlink Unity to mimic Mac folder layout
    mkdir -pv /Application/Unity/Hub/Editor/${UNITY_VERSION}/Editor/Data \
    && ln -sv /opt/Unity/Editor/Data/Managed /Application/Unity/Hub/Editor/${UNITY_VERSION}/Editor/Data/Managed \
    # Add Mono repository
    && APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=dontWarn \
        apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic main" | tee /etc/apt/sources.list.d/mono-official-stable.list \
    ## Install Mono
    && apt-get update \
    && apt-get install -y --no-install-recommends \
        mono-complete=6.8.0.105-0xamarin3+ubuntu1804b1 \
    # Cleanup cache
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*
