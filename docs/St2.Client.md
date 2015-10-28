#St2.Client


##St2.Client.Apis.ActionsApi
            
The actions api.
        
###Methods


####Constructor
Initializes a new instance of the TonyBaloney.St2.Client.Apis.ActionsApi class.
> #####Parameters
> **host:** The host.

> #####Exceptions
> **System.ArgumentNullException:** Thrown when one or more required arguments are null.


####GetActionsAsync
Get all available Actions.
> #####Return value
> A List of .

####GetActionsForPackAsync(System.String)
Gets actions for pack.
> #####Parameters
> **pack:** The pack name.

> #####Return value
> A List of .

####GetActionsByNameAsync(System.String)
Gets actions by name.
> #####Parameters
> **name:** The action name.

> #####Return value
> A List of .

####DeleteActionAsync(System.String)
Deletes the action described by actionId.
> #####Parameters
> **actionId:** can be either the ID (e.g. 1 or the ref e.g. mypack.myaction).

> #####Return value
> A Task.

####CreateActionAsync(TonyBaloney.St2.Client.Models.Action)
Creates a new action.
> #####Parameters
> **action:** The to create.

> #####Return value
> The new action asynchronous.

##St2.Client.Apis.IActionsApi
            
Interface for actions API.
        
###Methods


####GetActionsAsync
Get all available Actions.
> #####Return value
> A List of .

####GetActionsForPackAsync(System.String)
Gets actions for pack.
> #####Parameters
> **pack:** The pack name.

> #####Return value
> A List of .

####GetActionsByNameAsync(System.String)
Gets actions by name.
> #####Parameters
> **name:** The action name.

> #####Return value
> A List of .

####DeleteActionAsync(System.String)
Deletes the action described by actionId.
> #####Parameters
> **actionId:** can be either the ID (e.g. 1 or the ref e.g. mypack.myaction).


####CreateActionAsync(TonyBaloney.St2.Client.Models.Action)
Creates a new action.
> #####Parameters
> **action:** The to create.


##St2.Client.Apis.ExecutionsApi
            
The executions API.
            
> *See also: T:TonyBaloney.St2.Client.Apis.IExecutionsApi
        
###Methods


####Constructor
Initializes a new instance of the TonyBaloney.St2.Client.Apis.ExecutionsApi class.
> #####Parameters
> **host:** The host.

> #####Exceptions
> **System.ArgumentNullException:** Thrown when one or more required arguments are null.


####GetExecutionsAsync(System.Int32)
Gets a list of executions.
> #####Parameters
> **limit:** The number of items to return (default 5).

> #####Return value
> A list of .

####GetExecutionsForActionAsync(System.String,System.Int32)
Gets executions for action.
> #####Parameters
> **actionName:** Name of the action.

> **limit:** The number of items to return (default 5).

> #####Return value
> A list of .

##St2.Client.Apis.IExecutionsApi
            
Interface for executions API.
        
###Methods


####GetExecutionsAsync(System.Int32)
Gets a list of executions.
> #####Parameters
> **limit:** The number of items to return (default 5).

> #####Return value
> A list of .

####GetExecutionsForActionAsync(System.String,System.Int32)
Gets executions for action.
> #####Parameters
> **actionName:** Name of the action.

> **limit:** The number of items to return (default 5).

> #####Return value
> A list of .

##St2.Client.Apis.IPacksApi
            
Interface for packs API.
        
###Methods


####GetPacksAsync
Get a list of packs.
> #####Return value
> A List of .

####GetPacksByNameAsync(System.String)
Gets packs by name.
> #####Parameters
> **packName:** Name of the pack.

> #####Return value
> A List of .

####GetPacksByIdAsync(System.String)
Gets packs by identifier.
> #####Parameters
> **packId:** Identifier for the pack.

> #####Return value
> A List of .

##St2.Client.Apis.PacksApi
            
The packs api.
            
> *See also: T:TonyBaloney.St2.Client.Apis.IPacksApi
        
###Methods


####Constructor
Initializes a new instance of the TonyBaloney.St2.Client.Apis.PacksApi class.
> #####Parameters
> **host:** The host.

> #####Exceptions
> **System.ArgumentNullException:** Thrown when one or more required arguments are null.


####GetPacksAsync
Get a list of packs.
> #####Return value
> A List of .

####GetPacksByNameAsync(System.String)
Gets packs by name.
> #####Parameters
> **packName:** Name of the pack.

> #####Return value
> A List of .

####GetPacksByIdAsync(System.String)
Gets packs by identifier.
> #####Parameters
> **packId:** Identifier for the pack.

> #####Return value
> A List of .

##St2.Client.AuthExtensions
            
An authentication extensions.
        
###Methods


####AddXAuthToken(System.Net.Http.HttpClient,TonyBaloney.St2.Client.Models.TokenResponse)
A HttpClient extension method that adds an x-auth-token to the client headers
> #####Parameters
> **client:** The client to act on.

> **token:** The token.


##St2.Client.ISt2Client
            
Interface for StackStorm API client.
        
###Properties

####Actions
Accessor for the Actions related methods The actions accessor.
####Packs
Accessor for the Packs related methods. The Packs accessor.
####Executions
Accessor for the Executions related methods. The Executions accessor.
###Methods


####RefreshTokenAsync
Refresh the auth token.

####GetApiRequestAsync``1(System.String)
Make an asynchronous GET request to the API.
> #####Parameters
> **url:** URL of the GET request.

> #####Return value
> The Typed response.

####PostApiRequestAsync``2(System.String,``1)
Make an asynchronous POST request to the API.
> #####Parameters
> **url:** URL of the POST request.

> **request:** The request.

> #####Return value
> The Typed response.

####DeleteApiRequestAsync(System.String)
Make a DELETE request to the API.
> #####Parameters
> **url:** URL of the request.


##St2.Client.St2Client
            
StackStorm API Client.
        
###Fields

####_username
The username.
####_password
The password.
####_authUrl
URL of the authentication endpoint.
####_apiUrl
URL of the API.
####_token
The token.
###Properties

####Actions
Accessor for the Actions related methods. The actions accessor.
####Packs
Accessor for the Packs related methods. The Packs accessor.
####Executions
Accessor for the Executions related methods. The Executions accessor.
###Methods


####Constructor
Initializes a new instance of the TonyBaloney.St2.Client.St2Client class.
> #####Parameters
> **authUrl:** URL of the authentication endpoint.

> **apiUrl:** URL of the API.

> **username:** The username.

> **password:** The password.

> #####Exceptions
> **System.ArgumentException:** Thrown when one or more arguments have unsupported or illegal values.


####RefreshTokenAsync
Refresh the auth token.
> #####Return value
> A Task.

####GetApiRequestAsync``1(System.String)
Make an asynchronous GET request to the API.
> #####Parameters
> **url:** URL of the GET request.

> #####Return value
> The Typed response.

####PostApiRequestAsync``2(System.String,``1)
Make an asynchronous POST request to the API.
> #####Parameters
> **url:** URL of the POST request.

> **request:** The request.

> #####Return value
> The Typed response.

####DeleteApiRequestAsync(System.String)
Make a DELETE request to the API.
> #####Parameters
> **url:** URL of the request.

> #####Return value
> A Task.