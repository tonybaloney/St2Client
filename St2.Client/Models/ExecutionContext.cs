namespace TonyBaloney.St2.Client.Models
{
	public class ExecutionContext
	{
		public TriggerInstance trigger_instance { get; set; }
		public Rule rule { get; set; }
		public string user { get; set; }
	}
}
