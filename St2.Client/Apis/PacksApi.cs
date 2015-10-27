using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	public class PacksApi : IPacksApi
	{
		private ISt2Client _host;

		public PacksApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}
		public async Task<IList<Pack>> GetPacksAsync()
		{
			return await _host.GetApiRequestAsync<List<Pack>>("/v1/packs");
		}
	}
}
