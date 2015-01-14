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
        TResponse Execute<TResponse>(IWeChatRequest<TResponse> request) where TResponse : AbstractResponse;
        /// <summary>
        /// 验证消息真实性
        /// </summary>
        bool VerifySignature(string nonce, string timestamp, string token, string signature);
        /// <summary>
        /// 解析微信推送的消息
        /// </summary>
        WeChatBaseMsg Parse(string data);

	    /// <summary>
	    /// 验证消息真实性并解析加密的消息
	    /// </summary>
	    /// <param name="encryptData">加密串</param>
	    /// <param name="timestamp">时间戳</param>
	    /// <param name="nonce">随机串</param>
	    /// <param name="signature">签名串</param>
	    /// <param name="accessToken"></param>
	    /// <param name="appId"></param>
	    /// <param name="aesKey"></param>
	    /// <returns></returns>
	    WeChatBaseMsg ParseEncrypt(string encryptData, string timestamp, string nonce, string signature, string accessToken,
	                               string appId, string aesKey);
    }
}
