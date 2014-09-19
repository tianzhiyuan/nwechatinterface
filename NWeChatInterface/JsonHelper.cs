using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    internal static class JsonHelper
    {
        internal static string WriteObject(string name, string value)
        {
            return string.Format("\"{0}\":\"{1}\"", name, value);
        }
        internal static string WriteObject(string name, int value)
        {
            return string.Format("\"{0}\":{1}", name, value);
        }
        internal static string WriteObject(string name, long value)
        {
            return string.Format("\"{0}\":{1}", name, value);
        }
        internal static string WriteStart()
        {
            return "{";
        }
        internal static string WriteEnd()
        {
            return "}";
        }
    }
}
