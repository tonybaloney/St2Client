// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionStateExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Extension methods for working with PowerShell .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace TonyBaloney.St2.Client.PowerShell
{
	/// <summary>
	///     Extension methods for working with PowerShell <see cref="SessionState" />.
	/// </summary>
	/// <remarks>
	///     TODO: Add getter / setter for default connection.
	/// </remarks>
	public static class SessionStateExtensions
	{
		#region Constants

		/// <summary>
		///     Statically-cached empty list of compute service connections.
		/// </summary>
		/// <remarks>
		///     Returned when there are no active compute service connections.
		/// </remarks>
		private static readonly IReadOnlyDictionary<string, St2ClientConnection> EmptyConnectionList =
			new Dictionary<string, St2ClientConnection>();

		/// <summary>
		///     Variable name constants.
		/// </summary>
		public static class VariableNames
		{
			/// <summary>
			///     The name of the PowerShell variable in which active cloud-compute sessions are stored.
			/// </summary>
			public static readonly string ServiceSessions = "_St2ServiceComputeSessions";
		}

		#endregion // Constants

		/// <summary>
		///     The _default compute service connection name.
		/// </summary>
		private static string _defaultComputeServiceConnectionName;

		/// <summary>	Gets service connections from session. </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="sessionState">	. </param>
		/// <returns>	The service connections from session. </returns>
		private static Dictionary<string, St2ClientConnection> GetServiceConnectionsFromSession(
			SessionState sessionState)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ServiceSessions);
			if (connectionsVariable == null)
				return null;

			var connections = (Dictionary<string, St2ClientConnection>)connectionsVariable.Value;
			return connections;
		}

		/// <summary>	A SessionState extension method that gets service connections. </summary>
		/// <param name="sessionState">	. </param>
		/// <returns>	The service connections. </returns>
		public static IReadOnlyDictionary<string, St2ClientConnection> GetServiceConnections(
			this SessionState sessionState)
		{
			Dictionary<string, St2ClientConnection> connections = GetServiceConnectionsFromSession(sessionState);
			if (connections == null || connections.Count == 0)
				return EmptyConnectionList;

			return connections;
		}

		/// <summary>	A SessionState extension method that gets service connection by name. </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="sessionState">	. </param>
		/// <param name="name">		   	The name. </param>
		/// <returns>	The service connection by name. </returns>
		public static St2ClientConnection GetServiceConnectionByName(this SessionState sessionState, string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			Dictionary<string, St2ClientConnection> connections = GetServiceConnectionsFromSession(sessionState);
			if (connections == null || connections.Count == 0)
				return null;
			if (connections.ContainsKey(name))
				return connections[name];

			return null;
		}

		/// <summary>	A SessionState extension method that gets default service connection. </summary>
		/// <param name="sessionState">	. </param>
		/// <returns>	The default service connection. </returns>
		public static St2ClientConnection GetDefaultServiceConnection(this SessionState sessionState)
		{
			Dictionary<string, St2ClientConnection> connections = GetServiceConnectionsFromSession(sessionState);
			if (connections == null)
				return null;

			if (!connections.ContainsKey(_defaultComputeServiceConnectionName))
				return null;

			return connections[_defaultComputeServiceConnectionName];
		}

		/// <summary>	A SessionState extension method that sets default service connection. </summary>
		/// <exception cref="IndexOutOfRangeException">Thrown when the index is outside the required
		/// 										   range. </exception>
		/// <param name="sessionState">  	. </param>
		/// <param name="connectionName">	The connection Name. </param>
		public static void SetDefaultServiceConnection(this SessionState sessionState, string connectionName)
		{
			Dictionary<string, St2ClientConnection> connections = GetServiceConnectionsFromSession(sessionState);
			if (!connections.ContainsKey(connectionName))
				throw new IndexOutOfRangeException("connectionName does not exisits");
			_defaultComputeServiceConnectionName = connectionName;
		}

		/// <summary>	A SessionState extension method that adds a service connection. </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="sessionState">  	. </param>
		/// <param name="connectionName">	The connection Name. </param>
		/// <param name="connection">	 	The connection. </param>
		/// <returns>	A St2ClientConnection. </returns>
		public static St2ClientConnection AddServiceConnection(this SessionState sessionState,
			string connectionName, St2ClientConnection connection)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			if (connection == null)
				throw new ArgumentNullException("connection");


			if (string.IsNullOrEmpty(connectionName))
				throw new ArgumentNullException("connectionName");


			Dictionary<string, St2ClientConnection> connections;
			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ServiceSessions);
			if (connectionsVariable == null)
			{
				connectionsVariable = new PSVariable(
					VariableNames.ServiceSessions, connections = new Dictionary<string, St2ClientConnection>(),
					ScopedItemOptions.AllScope
					);
				sessionState.PSVariable.Set(connectionsVariable);
			}
			else
			{
				connections = (Dictionary<string, St2ClientConnection>)connectionsVariable.Value;
				if (connections == null)
				{
					connectionsVariable.Value = connections = new Dictionary<string, St2ClientConnection>();
					sessionState.PSVariable.Set(connectionsVariable);
				}
			}

			if (!connections.ContainsKey(connectionName))
				connections.Add(connectionName, connection);
			else
				connections[connectionName] = connection;

			if (string.IsNullOrEmpty(_defaultComputeServiceConnectionName) || connections.Count().Equals(1))
				_defaultComputeServiceConnectionName = connectionName;

			return connection;
		}

		/// <summary>	A SessionState extension method that removes the service connection. </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="sessionState">  	. </param>
		/// <param name="connectionName">	The connection Name. </param>
		/// <returns>	true if it succeeds, false if it fails. </returns>
		public static bool RemoveServiceConnection(this SessionState sessionState, string connectionName)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			if (string.IsNullOrEmpty(connectionName))
				throw new ArgumentNullException("connectionName");

			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ServiceSessions);
			if (connectionsVariable == null)
				return false;

			var connections = (Dictionary<string, St2ClientConnection>)connectionsVariable.Value;
			if (connections == null)
				return false;

			return connections.Remove(connectionName);
		}
	}
}