using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	using Action = Models.Action;

	[Cmdlet(VerbsLifecycle.Invoke, "St2Action")]
	public class InvokeActionCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "Action execution parameters")]
		public Hashtable Parameters;

		[Parameter(Mandatory = true, HelpMessage = "The name of the action to execute", ParameterSetName = "byName")]
		public string ActionName;

		[Parameter(Mandatory = true, HelpMessage = "The action to execute", ParameterSetName = "byObj")]
		public Action Action;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				Execution result;

				Dictionary<string, string> parameters = 
					Parameters.Keys.Cast<string>().ToDictionary(key => key, key => Parameters[key].ToString());

				if (!string.IsNullOrWhiteSpace(ActionName))
					result = Connection.ApiClient.Executions.ExecuteActionAsync(ActionName, parameters).Result;
				else
				{
					result = Connection.ApiClient.Executions.ExecuteActionAsync(Action.@ref, parameters).Result;
				}

				WriteObject(result);
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
