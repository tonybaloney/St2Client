using System;
using System.Collections.Generic;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsLifecycle.Install, "St2Pack")]
	public class InstallPackCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "Name of the pack to install")]
		public string Name;

		[Parameter(Mandatory = false, HelpMessage = "URL of the repository")]
		public string RepoUrl;

		[Parameter(Mandatory = false, HelpMessage = "Branch of the repository")]
		public string Branch;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				Dictionary<string, object> parameters = new Dictionary<string, object>();

				string[] pack_names = {Name};
				parameters.Add("packs", pack_names);

				if (!string.IsNullOrWhiteSpace(RepoUrl))
					parameters.Add("repo_url", RepoUrl);

				if (!string.IsNullOrWhiteSpace(Branch))
					parameters.Add("branch", Branch);

				Execution result = Connection.ApiClient.Executions.ExecuteActionAsync("packs.install", parameters).Result;
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
