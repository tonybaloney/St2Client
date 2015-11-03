using System.Net.Http;
using TonyBaloney.St2.Client.Exceptions;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client
{
	/// <summary>	An authentication extensions. </summary>
	public static class AuthExtensions
	{
		/// <summary>
		/// 	A HttpClient extension method that adds an x-auth-token to the client headers
		/// </summary>
		/// <param name="client">	The client to act on. </param>
		/// <param name="token"> 	The token. </param>
		public static void AddXAuthToken(this HttpClient client, TokenResponse token)
		{
			if (token == null)
				throw new InvalidTokenException("Please login first, or could not find a login token.");

			client.DefaultRequestHeaders.Add("x-auth-token", token.token);
		}
	}
}
