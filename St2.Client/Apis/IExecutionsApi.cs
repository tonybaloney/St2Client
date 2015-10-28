﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	Interface for executions API. </summary>
	public interface IExecutionsApi
	{
		/// <summary>	Gets a list of executions. </summary>
		/// <param name="limit">	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		Task<IList<Execution>> GetExecutionsAsync(int limit=5);

		/// <summary>	Gets executions for action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="limit">	 	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		Task<IList<Execution>> GetExecutionsForActionAsync(string actionName, int limit=5);
	}
}