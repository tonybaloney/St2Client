# St2Client

[![Build status](https://ci.appveyor.com/api/projects/status/y7rueuv6m1v0g7p8?svg=true)](https://ci.appveyor.com/project/tonybaloney/st2client)


A StackStorm API client for C#.NET including a PowerShell module

## Using the C#.NET client

### Documentation
 
The docs are available on readthedocs.org 
[![RTD](https://readthedocs.org/projects/st2client/badge/?version=latest)](http://st2client.readthedocs.org/en/latest/README/)

### Download packages
The .NET client is available on nuget.org
* Release - [![NuGet](https://img.shields.io/nuget/v/St2.Client.svg)](https://www.nuget.org/packages/St2.Client/)

### Example

```csharp
St2Client apiClient = new St2Client("http://12.3.2.3:9100", "http://12.3.2.3:9101", "testu", "testp");
// login and get a token
await apiClient.RefreshTokenAsync();

var actions = await apiClient.Actions.GetActionsAsync();
```

## Using the PowerShell module

The PowerShell Module includes the following commands:

* New-St2ClientConnection - Creates a new connection object
* Get-St2Actions - Get the actions (can filter by pack name)
* Get-St2Packs - Get the packs available
* Get-St2Executions - Get the executions
* Remove-St2Action - Delete an Action
* Invoke-St2Action - Invoke an Action

```powershell
Import-Module .\St2.Client.Powershell.dll
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
