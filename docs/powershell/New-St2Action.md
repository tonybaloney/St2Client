New-St2Action
===================

## SYNOPSIS
Create a new action inside a pack

## SYNTAX
```powershell
New-St2Action -Parameters <NamedActionParameter[]> -RunnerType <RunnerType> [-Connection <St2ClientConnection>] -Name <String> -Description <String> -EntryPoint <String> -Pack <Pack> [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]

New-St2Action -Parameters <NamedActionParameter[]> -RunnerType <RunnerType> [-Connection <St2ClientConnection>] -Name <String> -Description <String> -EntryPoint <String> -PackName <String> [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION


## PARAMETERS
### -Parameters &lt;NamedActionParameter[]&gt;
The collection of parameters created by New-St2ActionParameter
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -RunnerType &lt;RunnerType&gt;
The type of runner for the action
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Connection &lt;St2ClientConnection&gt;
The connection object (defaults to the one stored in the session)
```
Required?                    false
Position?                    named
Default value
Accept pipeline input?       true (ByPropertyName)
Accept wildcard characters?  false
```
 
### -Name &lt;String&gt;
The name of the action
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Description &lt;String&gt;
Description of the action
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -EntryPoint &lt;String&gt;
The entry point (script file name)
```
Required?                    true
Position?                    named
Default value
Accept pipeline input?       false
Accept wildcard characters?  false
```
 
### -Pack &lt;Pack&gt;
The pack to put the action into
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
 
### -PackName &lt;String&gt;
The pack name to put the action into
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
