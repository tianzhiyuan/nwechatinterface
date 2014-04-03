using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat
{
    public interface IResult
    {
        int errcode { get; set; }
        string errmsg { get; set; }
    }
}
