using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TonyBaloney.St2.Client.Models;

namespace TonyBaloney.St2.Client.Apis
{
	/// <summary>	The executions API. </summary>
	/// <seealso cref="T:TonyBaloney.St2.Client.Apis.IExecutionsApi"/>
	public class ExecutionsApi : IExecutionsApi
	{
		private ISt2Client _host;

		/// <summary>
		/// 	Initializes a new instance of the TonyBaloney.St2.Client.Apis.ExecutionsApi class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null. </exception>
		/// <param name="host">	The host. </param>
		public ExecutionsApi(ISt2Client host)
		{
			if (host == null)
				throw new ArgumentNullException("host");
			_host = host;
		}

		/// <summary>	Gets execution. </summary>
		/// <param name="id">	The identifier. </param>
		/// <returns>	The execution. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IExecutionsApi.GetExecutionAsync(string)"/>
		public async Task<Execution> GetExecutionAsync(string id)
		{
			return await _host.GetApiRequestAsync<Execution>("/v1/executions/"+id);
		}

		/// <summary>	Gets a list of executions. </summary>
		/// <param name="limit">	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IExecutionsApi.GetExecutionsAsync(int)"/>
		public async Task<IList<Execution>> GetExecutionsAsync(int limit = 5)
		{
			return await _host.GetApiRequestAsync<IList<Execution>>("/v1/executions?limit="+limit);
		}

		/// <summary>	Gets executions for action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="limit">	 	The number of items to return (default 5). </param>
		/// <returns>	A list of <see cref="Execution"/>. </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IExecutionsApi.GetExecutionsForActionAsync(string,int)"/>
		public async Task<IList<Execution>> GetExecutionsForActionAsync(string actionName, int limit = 5)
		{
			return await _host.GetApiRequestAsync<IList<Execution>>("/v1/executions?action="+actionName +"&limit="+limit);
		}

		/// <summary>	Executes the action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="parameters">	The parameters for the given action. </param>
		/// <returns>	The resulting execution; </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IExecutionsApi.ExecuteActionAsync(string,Dictionary{string,string})"/>
		public async Task<Execution> ExecuteActionAsync(string actionName, Dictionary<string, string> parameters)
		{
			ExecuteActionRequest request = new ExecuteActionRequest
			{
				action = actionName,
				parameters = parameters
			};
			return await _host.PostApiRequestAsync<Execution, ExecuteActionRequest>("/v1/executions/", request);
		}

		/// <summary>	Executes the action. </summary>
		/// <param name="actionName">	Name of the action. </param>
		/// <param name="parameters">	The parameters for the given action. </param>
		/// <returns>	The resulting execution; </returns>
		/// <seealso cref="M:TonyBaloney.St2.Client.Apis.IExecutionsApi.ExecuteActionAsync(string,Dictionary{string,object})"/>
		public async Task<Execution> ExecuteActionAsync(string actionName, Dictionary<string, object> parameters)
		{
			ExecuteComplexActionRequest request = new ExecuteComplexActionRequest
			{
				action = actionName,
				parameters = parameters
			};
			return await _host.PostApiRequestAsync<Execution, ExecuteComplexActionRequest>("/v1/executions/", request);
		}
	}
}
