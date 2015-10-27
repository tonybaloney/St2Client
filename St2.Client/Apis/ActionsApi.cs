using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	The actions api. </summary>
	public class ActionsApi : IActionsApi
	{
		private ISt2Client _host;

		public ActionsApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}

		public async Task<IList<Action>> GetActionsAsync()
		{
			return await _host.GetApiRequestAsync<List<Action>>("/v1/actions");
		}

		public async Task DeleteActionAsync(string actionId)
		{
			await _host.DeleteApiRequestAsync("/v1/actions/" + actionId);
		}

		public async Task CreateActionAsync(Action action)
		{
			await _host.PostApiRequestAsync<Action, Action>("/v1/actions/", action);
		}
	}
}
