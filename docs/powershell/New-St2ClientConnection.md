# New-St2ClientConnection
## SYNOPSIS
Create a new connection to a StackStorm (St2) API endpoint.

## SYNTAX
```powershell
New-St2ClientConnection -Username <String> -Password <String> [-Name <String>] -ApiUrl <String> -AuthApiUrl <String> [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a new connection to a StackStorm (St2) API endpoint by authenticating with a username/password credential and gathering an OAuth token to use in subsequent requests. Connections will be saved to the current session so you do not need to specify the -Connection parameter with each request.

## PARAMETERS
### -Username &lt;String&gt;
The username to authenticate with StackStorm
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Password &lt;String&gt;
The password to authenticate with StackStorm
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Name &lt;String&gt;
The name of your connection (optional)
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -ApiUrl &lt;String&gt;
The URL of the API, typically http(s)://(ip):9101/
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -AuthApiUrl &lt;String&gt;
The URL of the Authentication API, typically http(s)://(ip):9100/
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -InformationAction &lt;ActionPreference&gt;

```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -InformationVariable &lt;String&gt;

```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```

## INPUTS


## OUTPUTS


## NOTES


## EXAMPLES
