using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.New, "St2ActionParameter")]
	public class NewActionParameterCmdlet
		: PSCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "The name of the parameter")]
		public string Name { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "The type of the parameter")]
		public ParameterType Type { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Description of the parameter")]
		public string Description { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Is immutable")]
		public bool Immutable { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "Is immutable")]
		public bool Required { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "The name of the parameter")]
		public object DefaultValue { get; set; }

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			WriteObject(new NamedActionParameter
			{
				@default = DefaultValue,
				description = Description,
				required = Required,
				type = Type.ToString(),
				immutable = Immutable
			});
		}
	}
}
