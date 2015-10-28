using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	Interface for packs API. </summary>
	public interface IPacksApi
	{
		/// <summary>	Get a list of packs. </summary>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		Task<IList<Pack>> GetPacksAsync();

		/// <summary>	Gets packs by name. </summary>
		/// <param name="packName">	Name of the pack. </param>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		Task<IList<Pack>> GetPacksByNameAsync(string packName);

		/// <summary>	Gets packs by identifier. </summary>
		/// <param name="packId">	Identifier for the pack. </param>
		/// <returns>	A List of <see cref="Pack"/>. </returns>
		Task<IList<Pack>> GetPacksByIdAsync(string packId);
	}
}
