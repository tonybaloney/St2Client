using System;
using System.Collections.Generic;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Get, "St2Rules")]
	public class GetRulesCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = false, HelpMessage = "Show rules for a particular pack")] public string PackName;

		[Parameter(Mandatory = false, HelpMessage = "Show rules for a particular pack")] public Pack Pack;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IList<Rule> rules;

				if (Pack != null)
				{
					rules = Connection.ApiClient.Rules.GetRulesForPackAsync(Pack.name).Result;
				}
				else if (!string.IsNullOrWhiteSpace(PackName))
					rules = Connection.ApiClient.Rules.GetRulesForPackAsync(PackName).Result;
				else
				{
					rules = Connection.ApiClient.Rules.GetRulesAsync().Result;
				}


				foreach (var exec in rules)
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
