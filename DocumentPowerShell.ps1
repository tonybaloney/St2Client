Import-Module .\St2.Client.PowerShell\bin\Release\St2.Client.PowerShell.dll
$commands = Get-Command -Module St2.Client.PowerShell 

if((Test-Path ".\docs\powershell\") -eq 0){
    mkdir ".\docs\powershell\"}
foreach ($command in $commands){
	.\Get-HelpByMarkdown.ps1 $command.name | Set-Content -Encoding utf8 .\docs\powershell\$command.md
}