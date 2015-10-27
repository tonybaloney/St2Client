using System;
using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Packs")]
	public class GetPacksCmdlet
		: BaseClientCmdlet
	{
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				var packs = Connection.ApiClient.GetPacksAsync().Result;

				foreach (var pack in packs)
				{
					WriteObject(pack);
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
