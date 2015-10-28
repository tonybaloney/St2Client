namespace TonyBaloney.St2.Client.Models
{
	public class Execution
	{
			public string status { get; set; }
			public string start_timestamp { get; set; }
			public TriggerType trigger_type { get; set; }
			public Runner runner { get; set; }
			public Rule rule { get; set; }
			public Trigger trigger { get; set; }
			public ExecutionContext context { get; set; }
			public Action action { get; set; }
			public string id { get; set; }
			public string end_timestamp { get; set; }
	}
}
