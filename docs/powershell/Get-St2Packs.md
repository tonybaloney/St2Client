Get-St2Packs
===================

## SYNOPSIS
Get the packs installed in this StackStorm database

## SYNTAX
```powershell
Get-St2Packs [-Connection <St2ClientConnection>] [-Id <String>] [-Name <String>] [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
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
 
### -Id &lt;String&gt;

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
$MyPack = Get-St2Packs -Name "example"

foreach($action in $actions){
  Write-Output "Getting executions for action $action.name"
  Get-St2Executions -Action $action -Connection $conn
}
```


