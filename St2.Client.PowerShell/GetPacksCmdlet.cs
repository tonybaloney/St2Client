using System;
using System.Collections.Generic;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Packs")]
	public class GetPacksCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = false, HelpMessage = "Packs with ID")]
		public string Id;

		[Parameter(Mandatory = false, HelpMessage = "Packs with name")]
		public string Name;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				IList<Pack> packs;
				
				if (!string.IsNullOrWhiteSpace(Name))
					packs = Connection.ApiClient.Packs.GetPacksByNameAsync(Name).Result;
				else if (!string.IsNullOrWhiteSpace(Id))
					packs = Connection.ApiClient.Packs.GetPacksByIdAsync(Id).Result;
				else
					packs = Connection.ApiClient.Packs.GetPacksAsync().Result;

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
