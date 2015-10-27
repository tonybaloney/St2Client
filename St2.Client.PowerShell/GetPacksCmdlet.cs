using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Packs")]
	public class GetPacksCmdlet
		: BaseClientCmdlet
	{
		protected override void ProcessRecord()
		{
			var packs = Connection.ApiClient.GetPacksAsync().Result;

			foreach (var pack in packs)
			{
				WriteObject(pack);
			}
		}
	}
}
