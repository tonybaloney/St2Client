using System;

namespace TonyBaloney.St2.Client.PowerShell
{
	public sealed class St2ClientConnection
		: IDisposable
	{
		public St2ClientConnection(ISt2Client apiClient)
		{
			if (apiClient == null)
				throw new ArgumentNullException("apiClient");

			ApiClient = apiClient;
		}

		/// <summary>
		///     The API client represented by the connection.
		/// </summary>
		internal ISt2Client ApiClient { get; private set; }

		/// <summary>
		///     Dispose of resources being used by the CaaS API connection.
		/// </summary>
		public void Dispose()
		{
			if (ApiClient != null)
			{
				ApiClient.Dispose();
				ApiClient = null;
			}
		}
	}
}
