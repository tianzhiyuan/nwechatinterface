using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public abstract class AbstractResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
