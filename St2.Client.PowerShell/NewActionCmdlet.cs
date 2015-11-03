using System;
using System.Linq;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.New, "St2Action")]
	public class NewActionCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "Name of the action")] 
		public string Name;

		[Parameter(Mandatory = true, HelpMessage = "Description of the action")]
		public string Description;

		[Parameter(Mandatory = true, HelpMessage = "Entry point (script to run)")]
		public string EntryPoint;

		[Parameter(Mandatory = true, HelpMessage = "Collection of parameters for the action")]
		public NamedActionParameter[] Parameters { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "The target pack", ParameterSetName = "ByObj")]
		public Pack Pack;

		[Parameter(Mandatory = true, HelpMessage = "Name of the target pack", ParameterSetName = "ByName")]
		public string PackName;

		[Parameter(Mandatory = true, HelpMessage = "Type of runner for the action")]
		public RunnerType RunnerType { get; set; }

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (Pack != null)
					PackName = Pack.name;

				var Action = Connection.ApiClient.Actions.CreateActionAsync(new CreateAction
				{
					description = Description,
					enabled = true,
					entry_point = EntryPoint,
					name = Name,
					pack = PackName,
					parameters = Parameters.ToDictionary(item => item.name, item => (ActionParameter)item),
					runner_type = Enum.GetName(typeof(RunnerType), RunnerType)
				}).Result;

				WriteObject(Action);
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));

						return true;
					});
			}
		}
	}
}
