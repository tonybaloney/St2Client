# Get-St2Executions
## SYNOPSIS
Get a list of executions (run jobs)

## SYNTAX
```powershell
Get-St2Executions [-Connection <St2ClientConnection>] [-Limit <Int32>] [-ActionName <String>] [-Action <Action>] [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
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
 
### -Limit &lt;Int32&gt;
Limit the number of returned results
```
Required?                    false
Position?                    named
Default value                5
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -ActionName &lt;String&gt;
The name of the action, e.g. "libcloud.list_vms"
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Action &lt;Action&gt;
The Action object returned by Get-St2Actions
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


