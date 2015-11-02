Invoke-St2Action
===================

## SYNOPSIS
Invoke (run) an action within a pack

## SYNTAX
```powershell
Invoke-St2Action [-Connection <St2ClientConnection>] -Parameters <Hashtable> -ActionName <String> [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]

Invoke-St2Action [-Connection <St2ClientConnection>] -Parameters <Hashtable> -Action <Action> [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION


## PARAMETERS
### -Connection &lt;St2ClientConnection&gt;
The connection object (defaults to the one stored in the session)
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       true (ByPropertyName)
Accept wildcard characters?  false
```
 
### -Parameters &lt;Hashtable&gt;
Collection of parameters for the given action, each a Key-value-pair with the variable and the value.
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -ActionName &lt;String&gt;
The name of the action to run, including the pack name
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
 
### -Action &lt;Action&gt;
The action object, from Get-St2Actions
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```

## INPUTS


## OUTPUTS


## NOTES


## EXAMPLES
### Run an action by name
```powershell
Invoke-St2Action -ActionName "libcloud.list_vms" -Parameters @{"credentials"="my-aws"}
```

 
### Run an action by reference
```powershell
$action = Get-St2Actions -PackName "libcloud" -Name "list_vms"
```


