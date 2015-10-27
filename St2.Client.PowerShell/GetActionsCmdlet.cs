using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Actions")]
	public class GetActionsCmdlet
		: BaseClientCmdlet
	{
		protected override void ProcessRecord()
		{
			var actions = Connection.ApiClient.GetActionsAsync().Result;

			foreach (var action in actions)
			{
				WriteObject(action);
			}
		}
	}
}
