using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat
{
    /// <summary>
    /// marker interface represents a simple get request.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IGetRequest<TResult> : IWeChatRequest<TResult> where TResult : class , IResult
    {
    }
}
