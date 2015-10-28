using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	public interface IExecutionsApi
	{
		Task<IList<Execution>> GetExecutionsAsync(int limit=5);

		Task<IList<Execution>> GetExecutionsForActionAsync(string actionName, int limit=5);
	}
}
