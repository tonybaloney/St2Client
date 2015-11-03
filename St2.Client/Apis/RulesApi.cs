using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	The rules api. </summary>
	/// <seealso cref="T:TonyBaloney.St2.Client.Apis.IRulesApi"/>
	public class RulesApi :
		IRulesApi
	{
		/// <summary>	The host process. </summary>
		private ISt2Client _host;

		/// <summary>
		/// 	Initializes a new instance of the TonyBaloney.St2.Client.Apis.RulesApi class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="host">	The host. </param>
		public RulesApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}

		/// <summary>	Gets rules . </summary>
		/// <returns>	The rules . </returns>
		public async Task<IList<Rule>> GetRulesAsync()
		{
			return await _host.GetApiRequestAsync<IList<Rule>>("/v1/rules/");
		}

		/// <summary>	Gets rules for pack . </summary>
		/// <param name="packName">	Name of the pack. </param>
		/// <returns>	The rules for pack . </returns>
		public async Task<IList<Rule>> GetRulesForPackAsync(string packName)
		{
			return await _host.GetApiRequestAsync<IList<Rule>>("/v1/rules?pack=" + packName);
		}

		/// <summary>	Gets rules by name . </summary>
		/// <param name="name">	The rule name. </param>
		/// <returns>	The rules by name . </returns>
		public async Task<IList<Rule>> GetRulesByNameAsync(string name)
		{
			return await _host.GetApiRequestAsync<IList<Rule>>("/v1/rules?name=" + name);
		}
	}
}
