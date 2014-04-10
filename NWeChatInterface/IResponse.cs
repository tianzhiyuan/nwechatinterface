using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public interface IResponse
    {
        int errcode { get; set; }
        string errmsg { get; set; }
    }
}
