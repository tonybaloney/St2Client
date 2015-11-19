using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	Interface for executions  API. </summary>
	public interface IExecutionsApi
	{
		/// <summary>	Gets execution. </summary>
		/// <param name="id">	The identifier. </param>
		/// <returns>	The execution. </returns>
		Task<Execution> GetExecutionAsync(string id);

		/// <summary>	Gets a list of executions. </summary>
		/// <param name="limit">	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		Task<IList<Execution>> GetExecutionsAsync(int limit=5);

		/// <summary>	Gets executions for action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="limit">	 	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		Task<IList<Execution>> GetExecutionsForActionAsync(string actionName, int limit=5);

		/// <summary>	Executes the action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="parameters">	The parameters for the given action. </param>
		/// <returns>	The resulting execution; </returns>
		Task<Execution> ExecuteActionAsync(string actionName, Dictionary<string, string> parameters);

		/// <summary>	Executes the action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="parameters">	The parameters for the given action. </param>
		/// <returns>	The resulting execution; </returns>
		Task<Execution> ExecuteActionAsync(string actionName, Dictionary<string, object> parameters);
	}
}
