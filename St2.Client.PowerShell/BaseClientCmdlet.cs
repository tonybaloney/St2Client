using System.Management.Automation;
using System.Security.Authentication;

namespace TonyBaloney.St2.Client.PowerShell
{
	public abstract class BaseClientCmdlet
		: PSCmdlet
	{
		[Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
			HelpMessage = "The StackStorm Connection created by New-St2ClientConnection")]
		public St2ClientConnection Connection { get; set; }

		/// <summary>
		///     The begin processing.
		/// </summary>
		protected override void BeginProcessing()
		{
			base.BeginProcessing();

			// If CaaS connection is NOT set via parameter, get it from the PS session
			if (Connection == null)
			{
				Connection = SessionState.GetDefaultServiceConnection();
				if (Connection == null)
					ThrowTerminatingError(
						new ErrorRecord(
							new AuthenticationException(
								"Cannot find a valid connection. Use New-St2ClientConnection to create or Set-St2ActiveConnection to set a valid connection"),
							"-1",
							ErrorCategory.AuthenticationError,
							this));
			}
		}
	}
}
