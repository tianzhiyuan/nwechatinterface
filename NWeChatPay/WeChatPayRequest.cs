using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatPay
{
    public abstract class WeChatPayRequest
    {
    }

    public abstract class WeChatPayRequest<TResponse> : WeChatPayRequest where TResponse : WeChatPayResponse
    {

    }
}
