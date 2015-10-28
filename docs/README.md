# St2Client

A client for the [StackStorm](http://stackstorm.com) API to get actions, packs and execute actions from C#.NET

[![Build status](https://ci.appveyor.com/api/projects/status/y7rueuv6m1v0g7p8?svg=true)](https://ci.appveyor.com/project/tonybaloney/st2client)


## Using the C#.NET client

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