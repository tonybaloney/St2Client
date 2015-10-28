using System.Collections.Generic;

namespace TonyBaloney.St2.Client.Models
{
	public class Runner
	{
		public string runner_module { get; set; }
		public string description { get; set; }
		public bool enabled { get; set; }
		public Dictionary<string, RunnerParameter> runner_parameters { get; set; }
		public string id { get; set; }
		public string name { get; set; }
	}
}
