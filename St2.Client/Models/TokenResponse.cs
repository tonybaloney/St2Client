namespace TonyBaloney.St2.Client.Models
{
	public class TokenResponse
	{
		public string user { get; set; }
		public string token { get; set; }
		public string expiry { get; set; }
		public string id { get; set; }
		public object metadata { get; set; }
	}
}
