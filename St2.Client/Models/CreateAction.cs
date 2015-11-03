using System.Collections.Generic;

namespace TonyBaloney.St2.Client.Models
{
	public class CreateAction
	{
		public string description { get; set; }
		public string runner_type { get; set; }
		public bool enabled { get; set; }
		public string pack { get; set; }
		public string entry_point { get; set; }
		public Dictionary<string, ActionParameter> parameters { get; set; }
		public string name { get; set; }
	}
}
