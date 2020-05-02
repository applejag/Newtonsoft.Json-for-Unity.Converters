$ErrorActionPreference = "Stop"

function Publish-DockerImage  {
    Param (
        [parameter(ValueFromRemainingArguments = $true)]
        [string[]]$Passthrough
    )

    Write-Host "`n>> Publishing $Passthrough`n" -ForegroundColor DarkCyan
    docker push @Passthrough

    if ($LASTEXITCODE -ne 0) {
        throw "Failed to publish with args $Passthrough";
    }
}

Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-unity-tester:v1-2020.1.0b6-linux-il2cpp
Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-unity-tester:v1-2019.2.11f1
Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-unity-tester:v1-2018.4.14f1
Publish-DockerImage applejag/newtonsoft.json-for-unity.converters.package-unity-tester:latest

Write-Host "`n>> Done! `n" -ForegroundColor DarkGreen
