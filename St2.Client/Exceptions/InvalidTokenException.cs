using System;

namespace TonyBaloney.St2.Client.Exceptions
{
	/// <summary>	Exception for signalling invalid token errors. </summary>
	/// <seealso cref="T:System.Exception"/>
	public class InvalidTokenException
		: Exception
	{
		/// <summary>
		/// 	Initializes a new instance of the TonyBaloney.St2.Client.Exceptions.InvalidTokenException
		/// 	class.
		/// </summary>
		/// <param name="message">	The message. </param>
		public InvalidTokenException(string message) :
			base(message)
		{
		}
	}
}
