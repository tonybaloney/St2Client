using System.Threading.Tasks;
using TonyBaloney.St2.Client.Apis;

namespace TonyBaloney.St2.Client
{
	/// <summary>	Interface for StackStorm API client. </summary>
	public interface ISt2Client
	{
		/// <summary>	Refresh the auth token. </summary>
		Task RefreshTokenAsync();

		/// <summary>	Make an asynchronous GET request to the API. </summary>
		/// <typeparam name="TResponseType">	Expected Type of the response. </typeparam>
		/// <param name="url">	URL of the GET request. </param>
		/// <returns>	The Typed response. </returns>
		Task<TResponseType> GetApiRequestAsync<TResponseType>(string url);

		/// <summary>	Make an asynchronous POST request to the API. </summary>
		/// <typeparam name="TResponseType">	Expected Type of the response. </typeparam>
		/// <typeparam name="TRequestType"> 	Expected Type of of the request message. </typeparam>
		/// <param name="url">	  	URL of the POST request. </param>
		/// <param name="request">	The request. </param>
		/// <returns>	The Typed response. </returns>
		Task<TResponseType> PostApiRequestAsync<TResponseType, TRequestType>(string url, TRequestType request);

		/// <summary>	Make a DELETE request to the API. </summary>
		/// <param name="url">	URL of the request. </param>
		Task DeleteApiRequestAsync(string url);

		/// <summary>	Accessor for the Actions related methods </summary>
		/// <value>	The actions accessor. </value>
		IActionsApi Actions { get; }

		/// <summary>	Accessor for the Packs related methods. </summary>
		/// <value>	The Packs accessor. </value>
		IPacksApi Packs { get; }

		/// <summary>	Accessor for the Executions related methods. </summary>
		/// <value>	The Executions accessor. </value>
		IExecutionsApi Executions { get; }

		/// <summary>	Accessor for the Rules related methods. </summary>
		/// <value>	The Rules accessor. </value>
		IRulesApi Rules { get; }

		void Dispose();
	}
}