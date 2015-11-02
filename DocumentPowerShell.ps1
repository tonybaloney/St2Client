param ( 
 [string] $apiKey
)

Import-Module .\St2.Client.PowerShell\bin\Release\St2.Client.psd1
$commands = Get-Command -Module St2.Client

if((Test-Path ".\docs\powershell\") -eq 0){
    mkdir ".\docs\powershell\"}
foreach ($command in $commands){
	.\Get-HelpByMarkdown.ps1 $command.name | Set-Content -Encoding utf8 .\docs\powershell\$command.md
}
$modPath = $Env:PSModulePath.split(';')[1]
mkdir "$($modPath)\St2.Client"
Copy-Item .\nuget\nuget-anycpu.exe "C:\Program Files\PackageManagement\ProviderAssemblies\"
Copy-Item .\St2.Client.PowerShell\bin\Release\*.* "$($modPath)\St2.Client"
Publish-Module -Name St2.Client -NuGetApiKey $apiKey