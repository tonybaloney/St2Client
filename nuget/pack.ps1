$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\St2.Client\bin\Release\St2.Client.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\St2.Client\St2.Client.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content = (Get-Content $root\St2.Client.PowerShell\St2.Client.PowerShell.nuspec) 
$content = $content -replace '\$version\$',$versionStr