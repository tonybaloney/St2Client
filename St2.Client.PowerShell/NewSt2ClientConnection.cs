using System;
using System.Linq;
using System.Management.Automation;
using TonyBaloney.St2.Client.Exceptions;

namespace TonyBaloney.St2.Client.PowerShell
{
	/// <summary>
	///     The "New-CaasConnection" Cmdlet.
	/// </summary>
	/// <remarks>
	///     Used to create a new connection to the CaaS API.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "St2ClientConnection")]
	[OutputType(typeof (St2ClientConnection))]
	public class NewSt2ClientConnectionCmdlet : PSCmdlet
	{
		/// <summary>
		///     The credentials used to connect to the API.
		/// </summary>
		[Parameter(Mandatory = true)]
		[ValidateNotNullOrEmpty]
		public string Username { get; set; }

		[Parameter(Mandatory = true)]
		[ValidateNotNullOrEmpty]
		public string Password { get; set; }

		/// <summary>
		///     Name for this connection
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Name to identify this connection")]
		public string Name { get; set; }

		/// <summary>
		///     The base uri of the REST API
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The URL of the API")]
		public string ApiUrl { get; set; }

		/// <summary>
		///     The base uri of the auth API
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The URL of the Auth API")]
		public string AuthApiUrl { get; set; }

		[Parameter(Mandatory = false, HelpMessage = "Ignore certificate validation errors")]
		public SwitchParameter IgnoreCertificateValidation { get; set; }

		/// <summary>
		///     Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			St2Client apiClient = new St2Client(AuthApiUrl, ApiUrl, Username, Password, IgnoreCertificateValidation.ToBool());

			St2ClientConnection st2ClientConnection = new St2ClientConnection(apiClient);


			WriteDebug("Trying to login to the REST API");

			try
			{
				st2ClientConnection.ApiClient.RefreshTokenAsync().Wait(TimeSpan.FromSeconds(15));

				if (st2ClientConnection != null)
				{
					if (!st2ClientConnection.ApiClient.HasToken())
						ThrowTerminatingError(new ErrorRecord(new Exception("Could not login, check credentials and access to the API"), "100", ErrorCategory.AuthenticationError, st2ClientConnection ));

					WriteDebug(string.Format("connection created successfully: {0}", st2ClientConnection));
					if (string.IsNullOrEmpty(Name))
					{
						Name = Guid.NewGuid().ToString();
					}

					if (!SessionState.GetServiceConnections().Any())
						WriteDebug("This is the first connection and will be the default connection.");
					SessionState.AddServiceConnection(Name, st2ClientConnection);
					if (SessionState.GetServiceConnections().Count > 1)
						WriteWarning(
							"You have created more than one connection on this session, please use the cmdlet Set-St2ActiveConnection -Name <name> to change the active/default connection");

					SessionState.AddServiceConnection(Name, st2ClientConnection);
					WriteObject(st2ClientConnection);
				}
			}
			catch (FailedRequestException fre)
			{
				ThrowTerminatingError(new ErrorRecord(fre, "-1", ErrorCategory.AuthenticationError, null));
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.AuthenticationError, null));
						return true;
					});
			}
		}
	}
}
