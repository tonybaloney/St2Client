using System.Collections.Generic;

namespace TonyBaloney.St2.Client.Models
{
	public class Trigger
	{
		public string type { get; set; }
		public string @ref { get; set; }
		public Dictionary<string, string> parameters { get; set; }
	}
}
