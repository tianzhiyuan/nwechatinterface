using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public interface IWeChatService
    {
        TResponse Execute<TResponse>(IWeChatRequest<TResponse> request) where TResponse : class, IResponse;
        bool VerifySignature(string nonce, string timestamp, string token, string signature);
    }
}
