using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat
{
    /// <summary>
    /// Marker interface represents a request uses post method
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IPostRequest<TResult> : IWeChatRequest<TResult> where TResult : class ,IResult
    {

    }
}
