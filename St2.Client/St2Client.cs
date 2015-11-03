using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Apis;
using TonyBaloney.St2.Client.Models;
using TonyBaloney.St2.Client.Exceptions;

namespace TonyBaloney.St2.Client
{
	/// <summary>	StackStorm API Client. </summary>
	public class St2Client : ISt2Client, IDisposable
	{
		/// <summary>	The username. </summary>
		private string _username;

		/// <summary>	The password. </summary>
		private string _password;

		/// <summary>	URL of the authentication endpoint. </summary>
		private Uri _authUrl;

		/// <summary>	URL of the API. </summary>
		private Uri _apiUrl;

		/// <summary>	The token. </summary>
		private TokenResponse _token;

		/// <summary>
		/// 	Initializes a new instance of the TonyBaloney.St2.Client.St2Client class.
		/// </summary>
		/// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
		/// 									illegal values. </exception>
		/// <param name="authUrl"> 	URL of the authentication endpoint. </param>
		/// <param name="apiUrl">  	URL of the API. </param>
		/// <param name="username">	The username. </param>
		/// <param name="password">	The password. </param>
		public St2Client(string authUrl, string apiUrl, string username, string password)
		{
			if (String.IsNullOrWhiteSpace(authUrl))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'authUrl'.",
					"authUrl");

			if (String.IsNullOrWhiteSpace(apiUrl))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'apiUrl'.",
					"apiUrl");

			if (String.IsNullOrWhiteSpace(password))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'password'.",
					"password");

			if (String.IsNullOrWhiteSpace(username))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'username'.",
					"username");

			_apiUrl = new Uri(apiUrl);
			_authUrl = new Uri(authUrl);
			_password = password;
			_username = username;

			Actions = new ActionsApi(this);
			Packs = new PacksApi(this);
			Executions = new ExecutionsApi(this);
			Rules = new RulesApi(this);
		}

		/// <summary>	Refresh the auth token. </summary>
		/// <returns>	A Task. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.ISt2Client.RefreshTokenAsync()"/>
		public async Task RefreshTokenAsync()
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _authUrl;
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
					"Basic", 
					Convert.ToBase64String(
						System.Text.ASCIIEncoding.ASCII.GetBytes(
							string.Format("{0}:{1}", _username, _password))));

				try
				{
					var response = await client.PostAsync("/tokens", new StringContent(String.Empty));

					if (response.IsSuccessStatusCode)
						_token = await response.Content.ReadAsAsync<TokenResponse>();
					else
						throw ExceptionFactory.FailedTokenException(response);
				}
				catch (HttpRequestException hre)
				{
					throw new FailedRequestException(hre.Message);
				}
			}
		}

		/// <summary>	Make an asynchronous GET request to the API. </summary>
		/// <typeparam name="TResponseType">	Expected Type of the response. </typeparam>
		/// <param name="url">	URL of the GET request. </param>
		/// <returns>	The Typed response. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.ISt2Client.GetApiRequestAsync{TResponseType}(string)"/>
		public async Task<TResponseType> GetApiRequestAsync<TResponseType>(string url)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _apiUrl;
				client.AddXAuthToken(_token);

				try
				{
					var response = await client.GetAsync(url);
					if (response.IsSuccessStatusCode)
						return await response.Content.ReadAsAsync<TResponseType>();
					
					throw ExceptionFactory.FailedGetRequest(response);
				}
				catch (HttpRequestException hre)
				{
					throw new FailedRequestException(hre.Message);
				}
			}
		}

		/// <summary>	Make an asynchronous POST request to the API. </summary>
		/// <typeparam name="TResponseType">	Expected Type of the response. </typeparam>
		/// <typeparam name="TRequestType"> 	Expected Type of of the request message. </typeparam>
		/// <param name="url">	  	URL of the POST request. </param>
		/// <param name="request">	The request. </param>
		/// <returns>	The Typed response. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.ISt2Client.PostApiRequestAsync{TResponseType,TRequestType}(string,TRequestType)"/>
		public async Task<TResponseType> PostApiRequestAsync<TResponseType, TRequestType>(string url, TRequestType request)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _apiUrl;
				client.AddXAuthToken(_token);

				try
				{
					var response = await client.PostAsync(url, request, new JsonMediaTypeFormatter());
					if (response.IsSuccessStatusCode)
						return await response.Content.ReadAsAsync<TResponseType>();
					
					throw ExceptionFactory.FailedPostRequest(response);
				}
				catch (HttpRequestException hre)
				{
					throw new FailedRequestException(hre.Message);
				}
			}
		}

		/// <summary>	Make a DELETE request to the API. </summary>
		/// <param name="url">	URL of the request. </param>
		/// <returns>	A Task. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.ISt2Client.DeleteApiRequestAsync(string)"/>
		public async Task DeleteApiRequestAsync(string url)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _apiUrl;
				client.AddXAuthToken(_token);

				try
				{
					var response = await client.DeleteAsync(url);
					if (!response.IsSuccessStatusCode)
						throw ExceptionFactory.FailedDeleteRequest(response);
				}
				catch (HttpRequestException hre)
				{
					throw new FailedRequestException(hre.Message);
				}
			}
		}

		/// <summary>	Accessor for the Actions related methods. </summary>
		/// <value>	The actions accessor. </value>
		/// <seealso cref="P:TonyBaloney.St2.Client.ISt2Client.Actions"/>
		public IActionsApi Actions { get; private set; }

		/// <summary>	Accessor for the Packs related methods. </summary>
		/// <value>	The Packs accessor. </value>
		/// <seealso cref="P:TonyBaloney.St2.Client.ISt2Client.Packs"/>
		public IPacksApi Packs { get; private set; }

		/// <summary>	Accessor for the Executions related methods. </summary>
		/// <value>	The Executions accessor. </value>
		/// <seealso cref="P:TonyBaloney.St2.Client.ISt2Client.Executions"/>
		public IExecutionsApi Executions { get; private set; }

		/// <summary>	Accessor for the Rules related methods. </summary>
		/// <value>	The Rules accessor. </value>
		public IRulesApi Rules { get; private set; }

		public void Dispose()
		{
			// cleanup
		}

		public bool HasToken()
		{
			return _token != null;
		}
	}
}
