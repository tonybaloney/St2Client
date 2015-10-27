using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

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

		/// <summary>	Gets a list of packs in the StackStorm API. </summary>
		/// <returns>	A TPL Task. </returns>
		Task<IList<Pack>> GetPacksAsync();

		Task<IList<Action>> GetActionsAsync();
		void Dispose();
	}
}