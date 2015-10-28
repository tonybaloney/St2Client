#St2.Client


##St2.Client.Apis.ActionsApi
            
The actions api.
        

##St2.Client.AuthExtensions
            
An authentication extensions.
        
###Methods


####AddXAuthToken(System.Net.Http.HttpClient,TonyBaloney.St2.Client.Models.TokenResponse)
A HttpClient extension method that adds an x-auth-token to the client headers
> #####Parameters
> **client:** The client to act on.

> **token:** The token.


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
###Methods


####Constructor
Initializes a new instance of the St2.Client.St2Client class.
> #####Parameters
> **url:** URL of the API.

> **username:** The username.

> **password:** The password.


####RefreshTokenAsync
Refresh the token.
> #####Return value
> A Task.

####GetApiRequestAsync``1(System.String)
Gets API request asynchronously.
> #####Parameters
> **url:** URL of the document.

> #####Return value
> The TPL task.