# Invoke-St2Action
## SYNOPSIS

Invoke-St2Action -Parameters <hashtable> -ActionName <string> [-Connection <St2ClientConnection>] [<CommonParameters>]

Invoke-St2Action -Parameters <hashtable> -Action <Action> [-Connection <St2ClientConnection>] [<CommonParameters>]


## SYNTAX
```powershell
syntaxItem                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

----------                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

{@{name=Invoke-St2Action; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}, @{name=Invoke-St2Action; CommonParameters=True; WorkflowCommonParameters=False; parameter=System.Object[]}}
```

## DESCRIPTION


## PARAMETERS
### -Action &lt;Action&gt;
The action to execute
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           byObj
Aliases                      None
Dynamic?                     false
```
 
### -ActionName &lt;string&gt;
The name of the action to execute
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           byName
Aliases                      None
Dynamic?                     false
```
 
### -Connection &lt;St2ClientConnection&gt;
The StackStorm Connection created by New-St2ClientConnection
```
Position?                    Named
Accept pipeline input?       true (ByPropertyName)
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```
 
### -Parameters &lt;hashtable&gt;
Action execution parameters
```
Position?                    Named
Accept pipeline input?       false
Parameter set name           (All)
Aliases                      None
Dynamic?                     false
```

## INPUTS
TonyBaloney.St2.Client.PowerShell.St2ClientConnection


## OUTPUTS
System.Object

## NOTES


## EXAMPLES
