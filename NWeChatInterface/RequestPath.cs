using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public class RequestPath : Attribute
	{
		public string Path { get; private set; }
		public RequestPath(string path)
		{
			Path = path;
			IsFull = false;
		}
		public bool IsFull { get; set; }
	}
}
