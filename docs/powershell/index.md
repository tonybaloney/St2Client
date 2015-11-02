PowerShell Module for StackStorm
=============

Using 
-----

```powershell

Import-Module St2.Client
$conn = New-St2ClientConnection -Username testu -Password testp -ApiUrl "http://12.3.2.3:9101" -AuthApiUrl "http://12.3.2.3:9100"

$MyPack = Get-St2Packs -Name "example"

$actions = Get-St2Actions -Pack $MyPack

foreach($action in $actions){
  Write-Output "Getting executions for action $action.name"
  Get-St2Executions -Action $action -Connection $conn
}

$action = Get-St2Actions -PackName "st2_dimensiondata" -Name "list_locations"
Invoke-St2Action -Action $action -Parameters @{"region"="dd-au"}
```