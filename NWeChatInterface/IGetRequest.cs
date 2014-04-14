using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    /// <summary>
    /// marker interface represents a simple get request.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IGetRequest<TResponse> : IWeChatRequest<TResponse> where TResponse :  AbstractResponse
    {
    }
}
