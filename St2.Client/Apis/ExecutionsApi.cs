using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	public class ExecutionsApi : IExecutionsApi
	{
		private ISt2Client _host;

		public ExecutionsApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}

		public async Task<IList<Execution>> GetExecutionsAsync(int limit = 5)
		{
			return await _host.GetApiRequestAsync<IList<Execution>>("/v1/executions?limit="+limit);
		}

		public async Task<IList<Execution>> GetExecutionsForActionAsync(string actionName, int limit = 5)
		{
			return await _host.GetApiRequestAsync<IList<Execution>>("/v1/executions?action="+actionName +"&limit="+limit);
		}
	}
}
