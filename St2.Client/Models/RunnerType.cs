using System.ComponentModel;

namespace TonyBaloney.St2.Client.Models
{
	public enum RunnerType
	{
		[Description("local-shell-cmd")]
		LocalShellCmd,

		[Description("local-shell-script")]
		LocalShellScript,

		[Description("remote-shell-cmd")]
		RemoteShellCmd,

		[Description("python-script")]
		PythonScript,

		[Description("http-request")]
		HttpRequest,

		[Description("action-chain")]
		ActionChain,

		[Description("mistral-v2")]
		MistralV2,

		[Description("cloud-slang")]
		CloudSlang
	}
}
