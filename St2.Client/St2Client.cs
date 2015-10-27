using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;
using Action = TonyBaloney.St2.Client.Models.Action;

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

		private TokenResponse _token;

		/// <summary>	Initializes a new instance of the St2.Client.St2Client class. </summary>
		/// <param name="url">	   	URL of the API. </param>
		/// <param name="username">	The username. </param>
		/// <param name="password">	The password. </param>
		public St2Client(string authUrl, string apiUrl, string username, string password)
		{
			if (String.IsNullOrWhiteSpace(authUrl))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'authUrl'.", "authUrl");

			if (String.IsNullOrWhiteSpace(apiUrl))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'apiUrl'.", "apiUrl");

			if (String.IsNullOrWhiteSpace(password))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'password'.", "password");

			if (String.IsNullOrWhiteSpace(username))
				throw new ArgumentException("Argument cannot be null, empty, or composed entirely of whitespace: 'username'.", "username");

			_apiUrl = new Uri(apiUrl);
			_authUrl = new Uri(authUrl);
			_password = password;
			_username = username;
		}

		/// <summary>	Refresh the token. </summary>
		/// <returns>	A Task. </returns>
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
				var response = await client.PostAsync("/tokens", new StringContent(String.Empty));

				_token = await response.Content.ReadAsAsync<TokenResponse>();
			}
		}

		/// <summary>	Gets API request asynchronously. </summary>
		/// <typeparam name="TResponseType">	Type of the response type. </typeparam>
		/// <param name="url">	URL of the document. </param>
		/// <returns>	The TPL task. </returns>
		public async Task<TResponseType> GetApiRequestAsync<TResponseType>(string url)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = _apiUrl;
				client.AddXAuthToken(_token);

				var response = await client.GetAsync(url);

				return await response.Content.ReadAsAsync<TResponseType>();
			}
		}

		/// <summary>	Gets a list of packs in the StackStorm API. </summary>
		/// <returns>	A TPL Task. </returns>
		public async Task<IList<Pack>> GetPacksAsync()
		{
			return await GetApiRequestAsync<List<Pack>>("/v1/packs");
		}

		public async Task<IList<Action>> GetActionsAsync()
		{
			return await GetApiRequestAsync<List<Action>>("/v1/actions");
		}

		public void Dispose()
		{
			// cleanup
		}
	}
}
