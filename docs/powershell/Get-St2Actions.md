# Get-St2Actions
## SYNOPSIS
Get the available actions in a pack

## SYNTAX
```powershell
Get-St2Actions [-Connection <St2ClientConnection>] [-Pack <Pack>] [-PackName <String>] [-Name <String>] [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
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
 
### -Pack &lt;Pack&gt;
The pack object, returned by Get-St2Packs
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -PackName &lt;String&gt;
The name of the pack
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Name &lt;String&gt;

```
Required?                    false
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
### Example 1
```powershell
Get-St2Actions -PackName "st2_dimensiondata" -Name "list_locations"
```


