using namespace System.IO

param (
    [string] $VolumeSource = ([Path]::GetFullPath("$PSScriptRoot/..")),

    [string] $DockerImage = "applejag/newtonsoft.json-for-unity.converters.package-builder:v1-2019.2.11f1",

    [string] $WorkingDirectory = "/root/repo",

    [string] $RelativeBuildSolution = "Src/Newtonsoft.Json.UnityConverters/Newtonsoft.Json.UnityConverters.csproj",
    [string] $RelativeTestSolution = "Src/Newtonsoft.Json.UnityConverters.Tests/Newtonsoft.Json.UnityConverters.Tests.csproj",
    [string] $RelativeBuildDestination = "Src/UnityConvertersPackage/Plugins",
    [string] $RelativeAssetsFolder = "Src/UnityConvertersTestingProject/Assets",
    
    [switch] $DontUseNuGetPackageCache,
    [switch] $DontUseNuGetHttpCache
)

$ErrorActionPreference = "Stop"

Write-Host ">> Starting $DockerImage" -BackgroundColor DarkRed
$watch = [System.Diagnostics.Stopwatch]::StartNew()

$dockerVolumes = @(
    "${VolumeSource}:/root/repo"
)

$IsWSL = ($IsLinux -and $Env:WSL_DISTRO_NAME)

if (-not $DontUseNuGetPackageCache) {
    if ($IsWindows) {
        $dockerVolumes += @("$Env:UserProfile/.nuget/packages:/root/.nuget/packages")
    } elseif ($IsWSL) {
        $UserProfile = wslpath $(cmd.exe /C "echo %USERPROFILE%")
        $dockerVolumes += @("$UserProfile/.nuget/packages:/root/.nuget/packages")
    } elseif ($IsLinux) {
        $dockerVolumes += @("$Env:HOME/.nuget/packages:/root/.nuget/packages")
    }
}

if (-not $DontUseNuGetHttpCache) {
    if ($IsWindows) {
        $dockerVolumes += @("$Env:LocalAppData/NuGet/v3-cache:/root/.local/share/NuGet/v3-cache")
    } elseif ($IsWSL) {
        $LocalAppData = wslpath $(cmd.exe /C "echo %LOCALAPPDATA%")
        $dockerVolumes += @("$LocalAppData/NuGet/v3-cache:/root/.local/share/NuGet/v3-cache")
    } elseif ($IsLinux) {
        $dockerVolumes += @("$Env:HOME/.local/share/NuGet/v3-cache:/root/.local/share/NuGet/v3-cache")
    }
}

$dockerVolumesArgs
Write-Host @"
`$container = docker run -dit ``
    $(($dockerVolumes | ForEach-Object {"-v $_ ``"}) -join "`n    ")
    -e SCRIPTS=/root/repo/Build/Scripts ``
    -e BUILD_SOLUTION=/root/repo/$RelativeBuildSolution ``
    -e TEST_SOLUTION=/root/repo/$RelativeTestSolution ``
    -e BUILD_DESTINATION=/root/repo/$RelativeBuildDestination ``
    -e ASSETS_FOLDER=/root/repo/$RelativeAssetsFolder ``
    -e BUILD_CONFIGURATION=$Configuration ``
    -e BUILD_ADDITIONAL_CONSTANTS=$AdditionalConstants ``
    -e BASH_ENV=/root/.bashenv ``
    $DockerImage
"@ -ForegroundColor DarkGray

$container = docker run -dit `
    -v "${VolumeSource}:/root/repo" `
    -e SCRIPTS=/root/repo/Build/Scripts `
    -e BUILD_SOLUTION=/root/repo/$RelativeBuildSolution `
    -e TEST_SOLUTION=/root/repo/$RelativeTestSolution `
    -e BUILD_DESTINATION=/root/repo/$RelativeBuildDestination `
    -e ASSETS_FOLDER=/root/repo/$RelativeAssetsFolder `
    -e BUILD_CONFIGURATION=$Configuration `
    -e BUILD_ADDITIONAL_CONSTANTS=$AdditionalConstants `
    -e BASH_ENV=/root/.bashenv `
    $DockerImage

if (-not $?) {
    throw "Failed to create container"
}

function Invoke-DockerCommand ([string] $name, [string] $command) {
    Write-Host ">> $name " -BackgroundColor DarkBlue -ForegroundColor White
    Write-Host $command -ForegroundColor DarkGray
    @"
    set -o nounset
    set -o errexit
    set -o pipefail
    touch `$BASH_ENV
    chmod +x `$BASH_ENV
    source `$BASH_ENV

    $command
    echo 
"@ | docker exec -iw $WorkingDirectory $container bash
    if (-not $?) {
        throw "Failed to run command '$name'"
    }
    Write-Host ''
}

try {
    Invoke-DockerCommand "Setup variables" `
        '$SCRIPTS/build_setup_variables.sh'
    
    Invoke-DockerCommand "NuGet restore" @'
        msbuild -t:restore "$BUILD_SOLUTION" -p:TargetFramework=netstandard2.0
        msbuild -t:restore "$TEST_SOLUTION" -p:UnityBuild=Tests -p:TargetFramework=net472
'@

    Invoke-DockerCommand 'Build Release DLLs' `
        '$SCRIPTS/build.sh'

    Invoke-DockerCommand 'Build Debug DLLs' @'
        BUILD_CONFIGURATION=Debug \
        BUILD_DESTINATION=/workspace/debug \
        BUILD_ADDITIONAL_CONSTANTS= \
        $SCRIPTS/build.sh
'@

    Invoke-DockerCommand 'Build Newtonsoft.Json.UnityConverters.Tests' @'
        BUILD_SOLUTION="$TEST_SOLUTION" \
        BUILD_CONFIGURATION=Debug \
        BUILD_DESTINATION=/root/tmp/Newtonsoft.Json.UnityConverters.Tests/bin \
        BUILD_ADDITIONAL_CONSTANTS=UNITY_EDITOR_LINUX \
        BUILD_FRAMEWORK=net472 \
        $SCRIPTS/build.sh
'@

    Invoke-DockerCommand 'Move resulting package into workspace' @'
        mkdir -pv /workspace/package
        cp -rv /root/repo/Src/UnityConvertersPackage/. /workspace/package/
        cp -vf CHANGELOG.md /workspace/package/

        mkdir -pv /workspace/tests
        export BUILD_DESTINATION=/root/tmp/Newtonsoft.Json.UnityConverters.Tests/bin
        cp -rvt /workspace/tests/ \
            $BUILD_DESTINATION/Newtonsoft.Json.UnityConverters.Tests.dll \
            $BUILD_DESTINATION/Newtonsoft.Json.UnityConverters.Tests.pdb
'@

    Invoke-DockerCommand 'Fix meta files' `
        '$SCRIPTS/generate_metafiles.sh /workspace/package'
        
    Invoke-DockerCommand 'Copy dlls into Unity testing project' @'
        cp -vfr /workspace/tests/. $ASSETS_FOLDER/Plugins/
        cp -vfr /workspace/debug/. $ASSETS_FOLDER/Plugins/
'@

    Write-Host '>> Done!' -BackgroundColor Black -ForegroundColor DarkGray

} finally {
    $watch.Stop()
    Write-Host ">> Stopping $container" -BackgroundColor DarkGray
    docker kill $container | Out-Null
}

Write-Host ''
Write-Host "Full script completed in: $('{0:#,##}' -f $watch.ElapsedMilliseconds) ms" -ForegroundColor DarkGray
Write-Host ''
