using System.Collections.Generic;

namespace TonyBaloney.St2.Client.Models
{
	public class Rule
	{
		public string uid { get; set; }
		public List<object> tags { get; set; }
		public string @ref { get; set; }
		public bool enabled { get; set; }
		public Trigger trigger { get; set; }
		public object criteria { get; set; }
		public RuleAction action { get; set; }
		public string pack { get; set; }
		public RuleType type { get; set; }
		public string id { get; set; }
		public string name { get; set; }
	}
}
