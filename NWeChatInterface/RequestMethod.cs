using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NWeChatInterface
{
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public class RequestMethod : Attribute
	{
		public string Method { get; private set; }
		public RequestMethod(string method)
		{
			Method = method;
		}

		public const string POST = "POST";
		public const string GET = "GET";
	}
}
