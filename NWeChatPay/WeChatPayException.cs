using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    public class WeChatPayException:Exception
    {
        public WeChatPayException(string message) : base(message)
        {
            
        }

        public WeChatPayException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
