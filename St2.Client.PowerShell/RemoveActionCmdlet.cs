using System;
using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	using Action = Models.Action;

	[Cmdlet(VerbsCommon.Remove, "St2Action")]
	public class RemoveActionCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "Actions Id", ParameterSetName = "ById")] public string Id;

		[Parameter(Mandatory = true, HelpMessage = "Action", ParameterSetName = "ByObj")]
		public Action Action;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!String.IsNullOrWhiteSpace(Id))
					Connection.ApiClient.Actions.DeleteActionAsync(Id);
				else
				{
					Connection.ApiClient.Actions.DeleteActionAsync(Action.id);
				}
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
