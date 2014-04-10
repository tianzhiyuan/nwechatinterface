using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    /// <summary>
    /// Marker interface represents a request uses post method
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IPostRequest<TResponse> : IWeChatRequest<TResponse> where TResponse : class ,IResponse
    {
        string Data { get; }
    }
}
