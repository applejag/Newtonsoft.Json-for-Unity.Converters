$ErrorActionPreference = "Stop"

function Publish-DockerImage  {
    Param (
        [parameter(ValueFromRemainingArguments = $true)]
        [string[]]$Passthrough
    )

    Write-Host ">> Publishing $Passthrough" -BackgroundColor DarkCyan -ForegroundColor White
    docker push @Passthrough

    if ($LASTEXITCODE -ne 0) {
        throw "Failed to publish with args $Passthrough";
    }
}

Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-builder:v1-2019.2.11f1
Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-builder:v1-2018.4.14f1
Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-builder:latest
