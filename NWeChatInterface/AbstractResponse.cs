using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public abstract class AbstractResponse
    {
        public int errcode { get; internal set; }
        public string errmsg { get; internal set; }
    }
}
