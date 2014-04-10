using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public interface IWeChatService
    {
        /// <summary>
        /// 向微信服务器发送命令请求
        /// </summary>
        TResponse Execute<TResponse>(IWeChatRequest<TResponse> request) where TResponse : class, IResponse;
        /// <summary>
        /// 验证消息真实性
        /// </summary>
        bool VerifySignature(string nonce, string timestamp, string token, string signature);
        /// <summary>
        /// 解析微信推送的消息
        /// </summary>
        WeChatBaseMsg Parse(string data);
    }
}
