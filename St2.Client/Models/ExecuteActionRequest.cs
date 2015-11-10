using System.Collections.Generic;

namespace TonyBaloney.St2.Client.Models
{
	public class ExecuteActionRequest
	{
		public string action;
		public Dictionary<string, string> parameters;
	}

	public class ExecuteComplexActionRequest
	{
		public string action;
		public Dictionary<string, object> parameters;
	}
}
