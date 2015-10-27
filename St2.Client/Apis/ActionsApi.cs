using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TonyBaloney.St2.Client.Apis
{
	using Action=Models.Action;

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

		public async Task<IList<Action>> GetActionsForPackAsync(string pack)
		{
			return await _host.GetApiRequestAsync<List<Action>>("/v1/actions?pack=" + pack);
		}

		public async Task<IList<Action>> GetActionsByNameAsync(string name)
		{
			return await _host.GetApiRequestAsync<List<Action>>("/v1/actions?name=" + name);
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
