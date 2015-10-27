# St2Client
A StackStorm API client for C#.NET including a PowerShell module

## Using the C#.NET client

```csharp
St2Client apiClient = new St2Client("http://12.3.2.3:9100", "http://12.3.2.3:9101", "testu", "testp");
// login and get a token
await apiClient.RefreshTokenAsync();

var actions = await apiClient.GetActionsAsync();
```

## Using the PowerShell module

```powershell
Import-Module .\St2.Client.Powershell.dll
$conn = New-St2ClientConnection -Username testu -Password testp -ApiUrl "http://12.3.2.3:9101" -AuthApiUrl "http://12.3.2.3:9100"

Get-St2Packs -Connection $conn | ft

Get-St2Actions -Connection $conn | ft

```
