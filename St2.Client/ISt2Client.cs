using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Apis;

namespace TonyBaloney.St2.Client
{
	public interface ISt2Client
	{
		/// <summary>	Refresh the token. </summary>
		/// <returns>	A Task. </returns>
		Task RefreshTokenAsync();

		/// <summary>	Gets API request asynchronously. </summary>
		/// <typeparam name="TResponseType">	Type of the response type. </typeparam>
		/// <param name="url">	URL of the document. </param>
		/// <returns>	The TPL task. </returns>
		Task<TResponseType> GetApiRequestAsync<TResponseType>(string url);

		Task<TResponseType> PostApiRequestAsync<TResponseType, TRequestType>(string url, TRequestType request);

		Task DeleteApiRequestAsync(string url);

		IActionsApi Actions { get; }

		IPacksApi Packs { get; }

		IExecutionsApi Executions { get; }

		void Dispose();
	}
}