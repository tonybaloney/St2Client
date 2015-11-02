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

# put nuget-anycpu somewhere this module can find it
$modPath = $Env:PSModulePath.split(';')[1]
mkdir "$($modPath)\St2.Client"

if ((Test-Path "C:\Users\appveyor\AppData\Local\PackageManagement") -eq 0){
	mkdir "C:\Users\appveyor\AppData\Local\PackageManagement"
}
if ((Test-Path "C:\Users\appveyor\AppData\Local\PackageManagement\ProviderAssemblies") -eq 0){
	mkdir "C:\Users\appveyor\AppData\Local\PackageManagement\ProviderAssemblies"
}

Copy-Item .\nuget\nuget-anycpu.exe "C:\Users\appveyor\AppData\Local\PackageManagement\ProviderAssemblies\NuGet-anycpu.exe" -Verbose

# Install the module
Copy-Item .\St2.Client.PowerShell\bin\Release\*.* "$($modPath)\St2.Client" -Verbose

# publish the module
Publish-Module -Name St2.Client -NuGetApiKey $apiKey