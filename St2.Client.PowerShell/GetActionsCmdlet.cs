using System;
using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Actions")]
	public class GetActionsCmdlet
		: BaseClientCmdlet
	{
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				var actions = Connection.ApiClient.Actions.GetActionsAsync().Result;

				foreach (var action in actions)
				{
					WriteObject(action);
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
