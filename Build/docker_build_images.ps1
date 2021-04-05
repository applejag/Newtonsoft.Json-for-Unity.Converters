#!/usr/bin/env pwsh

using namespace System.Collections.Generic

[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact='Medium')]
Param (
    [switch]
    $Force
)

$ErrorActionPreference = "Stop"

if (-not $PSBoundParameters.ContainsKey('Confirm')) {
    $ConfirmPreference = $PSCmdlet.SessionState.PSVariable.GetValue('ConfirmPreference')
}
if (-not $PSBoundParameters.ContainsKey('WhatIf')) {
    $WhatIfPreference = $PSCmdlet.SessionState.PSVariable.GetValue('WhatIfPreference')
}

class DockerBuild {
    [string] $ImageNameKey
    [string] $ImageVersion
    [List[string]] $ExtraArgs
    [bool] $Latest

    DockerBuild([string] $ImageNameKey, [string] $ImageVersion) {
        $this.ImageNameKey = $ImageNameKey
        $this.ImageVersion = $ImageVersion
        $this.ExtraArgs = [List[string]]::new()
        $this.Latest = $false
    }

    [DockerBuild] WithExtraArg([string] $ExtraSwitch) {
        $this.ExtraArgs.Add($ExtraSwitch)
        return $this
    }
    [DockerBuild] WithExtraArg([string] $ExtraKey, [string] $ExtraValue) {
        $this.ExtraArgs.Add($ExtraKey)
        $this.ExtraArgs.Add($ExtraValue)
        return $this
    }
    [DockerBuild] IsLatest() {
        $this.Latest = $true
        return $this
    }
}

function Start-DockerBuild  {
    [CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact='Medium')]
    Param (
        [parameter(ValueFromPipeline=$true)]
        [DockerBuild] $Build
    )

    Process {
        $ImageName = "applejag/newtonsoft.json-for-unity.converters.$($Build.ImageNameKey)"
        $DockerFile = "$PSScriptRoot/$($Build.ImageNameKey).Dockerfile"
        $ImageVersion = $Build.ImageVersion
        $ExtraArgs = $Build.ExtraArgs
        $ImageTags = @("${ImageVersion}")

        if ($Build.Latest) {
            $ImageTags += "latest"
        }

        $ImageTagArgs = $ImageTags | ForEach-Object { "-t${ImageName}:$_" } -Confirm:$false -WhatIf:$false
        $ImageTagsJoined = $ImageTags -join ", "

        if ($Force -or $PSCmdlet.ShouldProcess("${ImageName}, $($ImageTags.Length) tag(s): $ImageTagsJoined")) {
            Write-Host "`n>> Building ${ImageName} " -ForegroundColor DarkGreen
            if ($ExtraArgs.Count -gt 0) {
                Write-Host "Extra args ($($ExtraArgs.Count)): $ExtraArgs" -ForegroundColor Yellow
            }
            Write-Host "Image tags ($($ImageTagArgs.Length)): $ImageTagsJoined" -ForegroundColor Yellow
            Write-Host ""
            docker build `
                -f $DockerFile `
                --build-arg IMAGE_VERSION=${ImageVersion} `
                @ImageTagArgs `
                @ExtraArgs `
                $PSScriptRoot

            if (-not $?) {
                throw "Failed to build with args $ExtraArgs";
            }
        } else {
            Write-Host "`n>> Skipping building $ImageName, $($ImageTags.Length) tag(s): $ImageTagsJoined `n" -ForegroundColor DarkGray
        }
    }
}

$Builds = [DockerBuild[]] @(
    , [DockerBuild]::new('package-deploy-npm', 'v3').
        IsLatest().
        WithExtraArg('--build-arg', 'IMAGE_VERSION=v3')

    , [DockerBuild]::new('package-deploy-github', 'v4').
        IsLatest().
        WithExtraArg('--build-arg', 'IMAGE_VERSION=v4')

    , [DockerBuild]::new('package-unity-tester', 'v1-2018.4.14f1').
        WithExtraArg('--build-arg', 'UNITY_VERSION=2018.4.14f1')

    , [DockerBuild]::new('package-unity-tester', 'v1-2019.2.11f1').
        WithExtraArg('--build-arg', 'UNITY_VERSION=2019.2.11f1')

    , [DockerBuild]::new('package-unity-tester', 'v1-2020.1.0b6-linux-il2cpp').
        IsLatest().
        WithExtraArg('--build-arg', 'UNITY_VERSION=2020.1.0b6-linux-il2cpp')
)

$Builds | Start-DockerBuild

Write-Host "`n>> Done! `n" -ForegroundColor DarkGreen
