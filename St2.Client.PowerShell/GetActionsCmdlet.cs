using System;
using System.Collections.Generic;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	using Action = Models.Action;

	[Cmdlet(VerbsCommon.Get, "St2Actions")]
	public class GetActionsCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = false, HelpMessage = "Actions for a particular pack")] public Pack Pack;

		[Parameter(Mandatory = false, HelpMessage = "Actions for a particular pack")] public string PackName;

		[Parameter(Mandatory = false, HelpMessage = "Actions with name")] public string Name;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IList<Action> actions;

				if (!String.IsNullOrWhiteSpace(PackName))
					actions = Connection.ApiClient.Actions.GetActionsForPackAsync(PackName).Result;
				else if (Pack != null)
					actions = Connection.ApiClient.Actions.GetActionsForPackAsync(Pack.name).Result;
				else if (!String.IsNullOrWhiteSpace(Name))
					actions = Connection.ApiClient.Actions.GetActionsByNameAsync(Name).Result;
				else
				{
					actions = Connection.ApiClient.Actions.GetActionsAsync().Result;
				}


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
