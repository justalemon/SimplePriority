param (
    [Parameter(Mandatory=$true)][string]$BSIPAVersion,
    [Parameter(Mandatory=$true)][string]$BSMLVersion
)

$global:ProgressPreference = "SilentlyContinue"

$bsipa_path = "sdk\\bsipa"
$bsml_path = "sdk\\bsml"

function Get-AndInstall {
    param (
        [Parameter(Mandatory=$true)][PSCustomObject]$Mod
    )

    $path = "sdk\\$($Mod.name)"
    $zip = "sdk\\$($Mod.name)-$($Mod.version).zip"

    Invoke-WebRequest -Uri "https://beatmods.com$($Mod.downloads.url)" -OutFile $zip
    Expand-Archive -Path "sdk\\$($Mod.name)-$($Mod.version).zip" -DestinationPath $path
    Remove-Item -Path $zip
}

if (!(Test-Path $bsipa_path) -or !(Test-Path $bsml_path)) {
    Write-Host "Requesting the list of mods from Beat Mods"

    $response = Invoke-WebRequest -Uri "https://beatmods.com/api/v1/mod" -UseBasicParsing
    $mods = ConvertFrom-Json -InputObject $response

    $bsipa = $null
    $bsml = $null

    foreach ($mod in $mods) {
        if ($mod.name -eq "BSIPA" -and $mod.version -eq $BSIPAVersion) {
            $bsipa = $mod
        }
        elseif ($mod.name -eq "BeatSaberMarkupLanguage" -and $mod.version -eq $BSMLVersion) {
            $bsml = $mod
        }
    }

    if ($null -eq $bsipa) {
        Write-Error "Couldn't find matching BSIPA version"
    }
    elseif (Test-Path $bsipa_path) {
    }
    else {
        Write-Host "Found $($bsipa.name) version $($bsipa.version) for game version $($bsipa.gameVersion)"
        Get-AndInstall -Mod $bsipa
    }

    if ($null -eq $bsml) {
        Write-Error "Couldn't find matching BSML version"
    }
    elseif (Test-Path $bsml_path) {
    }
    else {
        Write-Host "Found $($bsml.name) version $($bsml.version) for game version $($bsml.gameVersion)"
        Get-AndInstall -Mod $bsml
    }
}
