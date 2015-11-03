using System;
using System.Management.Automation;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.PowerShell
{
	[Cmdlet(VerbsCommon.Remove, "St2Rule")]
	public class RemoveRuleCmdlet
		: BaseClientCmdlet
	{
		[Parameter(Mandatory = true, HelpMessage = "Rule Id", ParameterSetName = "ById")] 
		public string Id;

		[Parameter(Mandatory = true, HelpMessage = "Rule", ParameterSetName = "ByObj")]
		public Rule Rule;

		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!String.IsNullOrWhiteSpace(Id))
					Connection.ApiClient.Rules.DeleteRuleAsync(Id);
				else
				{
					Connection.ApiClient.Rules.DeleteRuleAsync(Rule.id);
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
