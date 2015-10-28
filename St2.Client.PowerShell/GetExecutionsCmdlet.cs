using System;
using System.Collections.Generic;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	using Action = Models.Action;

	[Cmdlet(VerbsCommon.Get, "St2Executions")]
	public class GetExecutionsCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = false, HelpMessage = "Limit the number of results")] public int Limit=5;

		[Parameter(Mandatory = false, HelpMessage = "Show executions for a particular action")] public string ActionName;

		[Parameter(Mandatory = false, HelpMessage = "Show executions for a particular action")] public Action Action;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IList<Execution> executions;

				if (Action != null)
				{
					executions = Connection.ApiClient.Executions.GetExecutionsForActionAsync(Action.name, Limit).Result;
				}
				else if (!string.IsNullOrWhiteSpace(ActionName))
					executions = Connection.ApiClient.Executions.GetExecutionsForActionAsync(ActionName).Result;
				else
				{
					executions = Connection.ApiClient.Executions.GetExecutionsAsync(Limit).Result;
				}


				foreach (var exec in executions)
				{
					WriteObject(exec);
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
