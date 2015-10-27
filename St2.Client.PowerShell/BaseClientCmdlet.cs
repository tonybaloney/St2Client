using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	public abstract class BaseClientCmdlet
		: PSCmdlet
	{
		[Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
			HelpMessage = "The StackStorm Connection created by New-St2ClientConnection")]
		public St2ClientConnection Connection { get; set; }
	}
}
