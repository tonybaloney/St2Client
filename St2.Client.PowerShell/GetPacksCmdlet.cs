using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Packs")]
	public class GetPacksCmdlet
		: BaseClientCmdlet
	{
		protected async override void ProcessRecord()
		{
			var packs = await Connection.ApiClient.GetPacksAsync();

			foreach (var pack in packs)
			{
				WriteObject(pack);
			}
		}
	}
}
