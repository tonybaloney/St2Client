using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	The packs api. </summary>
	/// <seealso cref="T:TonyBaloney.St2.Client.Apis.IPacksApi"/>
	public class PacksApi : IPacksApi
	{
		private ISt2Client _host;

		/// <summary>
		/// 	Initializes a new instance of the TonyBaloney.St2.Client.Apis.PacksApi class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="host">	The host. </param>
		public PacksApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}

		/// <summary>	Get a list of packs. </summary>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IPacksApi.GetPacksAsync()"/>
		public async Task<IList<Pack>> GetPacksAsync()
		{
			return await _host.GetApiRequestAsync<List<Pack>>("/v1/packs");
		}

		/// <summary>	Gets packs by name. </summary>
		/// <param name="packName">	Name of the pack. </param>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IPacksApi.GetPacksByNameAsync(string)"/>
		public async Task<IList<Pack>> GetPacksByNameAsync(string packName)
		{
			return await _host.GetApiRequestAsync<List<Pack>>("/v1/packs?name=" + packName);
		}

		/// <summary>	Gets packs by identifier. </summary>
		/// <param name="packId">	Identifier for the pack. </param>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IPacksApi.GetPacksByIdAsync(string)"/>
		public async Task<IList<Pack>> GetPacksByIdAsync(string packId)
		{
			return await _host.GetApiRequestAsync<List<Pack>>("/v1/packs?ref=" + packId);
		}
	}
}
