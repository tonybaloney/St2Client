using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	Interface for rules API. </summary>
	public interface IRulesApi
	{
		/// <summary>	Gets rules. </summary>
		/// <returns>	The rules. </returns>
		Task<IList<Rule>> GetRulesAsync();

		/// <summary>	Gets rules for pack. </summary>
		/// <param name="packName">	Name of the pack. </param>
		/// <returns>	The rules for pack. </returns>
		Task<IList<Rule>> GetRulesForPackAsync(string packName);

		/// <summary>	Gets rules by name. </summary>
		/// <param name="name">	The name. </param>
		/// <returns>	The rules by name. </returns>
		Task<IList<Rule>> GetRulesByNameAsync(string name);

		/// <summary>	Deletes the rule described by ruleId. </summary>
		/// <param name="ruleId">	Identifier for the rule. </param>
		/// <returns>	A Task. </returns>
		Task DeleteRuleAsync(string ruleId);
	}
}
