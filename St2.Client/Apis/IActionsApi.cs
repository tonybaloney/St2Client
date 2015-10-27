using System.Collections.Generic;
using System.Threading.Tasks;

namespace TonyBaloney.St2.Client.Apis
{
	using Action = Models.Action;

	public interface IActionsApi
	{
		Task<IList<Action>> GetActionsAsync();

		Task<IList<Action>> GetActionsForPackAsync(string pack);

		Task<IList<Action>> GetActionsByNameAsync(string name);

		/// <summary>	Deletes the action described by actionId. </summary>
		/// <param name="actionId">	can be either the ID (e.g. 1 or the ref e.g. mypack.myaction). </param>
		/// <returns>	A Task. </returns>
		Task DeleteActionAsync(string actionId);

		Task CreateActionAsync(Action action);
	}
}
