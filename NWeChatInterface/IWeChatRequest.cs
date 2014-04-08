using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface
{
    /// <summary>
    /// marker interface
    /// </summary>
    public interface IWeChatRequest
    {
        [JsonIgnore]
        string RequestUrl { get; }
    }
    public interface IWeChatRequest<TResult>:IWeChatRequest where TResult:class , IResult
    {
        
    }
}
