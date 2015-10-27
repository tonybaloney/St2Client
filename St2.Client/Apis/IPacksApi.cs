using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	public interface IPacksApi
	{
		Task<IList<Pack>> GetPacksAsync();
	}
}
