using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Actions")]
	public class GetActionsCmdlet
		: BaseClientCmdlet
	{
		protected async override void ProcessRecord()
		{
			var actions = await Connection.ApiClient.GetActionsAsync();

			foreach (var action in actions)
			{
				WriteObject(action);
			}
		}
	}
}
