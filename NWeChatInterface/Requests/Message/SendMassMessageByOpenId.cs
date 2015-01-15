using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Message
{
	/// <summary>
	/// 群发消息
	/// 在公众平台网站上，为订阅号提供了每天一条的群发权限，为服务号提供每月（自然月）4条的群发权限。
	/// 
	/// 
	/// 1、该接口暂时仅提供给已微信认证的服务号
	/// 2、虽然开发者使用高级群发接口的每日调用限制为100次，但是用户每月只能接收4条，请小心测试
	/// 3、无论在公众平台网站上，还是使用接口群发，用户每月只能接收4条群发消息，多于4条的群发将对该用户发送失败。
	/// 4、具备微信支付权限的公众号，在使用高级群发接口上传、群发图文消息类型时，可使用a标签加入外链
	/// </summary>
	[RequestPath("/cgi-bin/message/mass/send")]
	public class SendMassMessageByOpenId : AccessRequiredRequest<SendMassMessageResponse>
	{
		/// <summary>
		/// 消息类型，包括语音voice,图片image，文本text，多图文news，视频video<see cref="WeChatMessageTypes"/>
		/// </summary>
		public string Type { get; set; }



		public string[] UserIds { get; set; }
		/// <summary>
		/// 如果消息类型问文本，这里可以直接输入文本内容，其他则输入media_id
		/// </summary>
		public string ContentOrMediaId { get; set; }



		public override string Data
		{
			get
			{
				var sb = new StringBuilder();
				sb.Append("{");

				sb.AppendFormat("\"touser\":[{0}],",
								string.Join(",", this.UserIds.Select(o => string.Format("\"{0}\"", o))));

				switch (Type)
				{
					case WeChatMessageTypes.TEXT:
						sb.AppendFormat("\"text\":{{{0}}},", JsonHelper.WriteObject("content", this.ContentOrMediaId));
						sb.AppendFormat("\"msgtype\":\"text\"");
						break;
					case WeChatMessageTypes.IMAGE:
						sb.AppendFormat("\"image\":{{{0}}},", JsonHelper.WriteObject("media_id", this.ContentOrMediaId));
						sb.AppendFormat("\"msgtype\":\"image\"");
						break;
					case WeChatMessageTypes.NEWS:
						sb.AppendFormat("\"mpnews\":{{\"media_id\":\"{0}\"}},", this.ContentOrMediaId);
						sb.AppendFormat("\"msgtype\":\"mpnews\"");
						break;
					case WeChatMessageTypes.VIDEO:
						sb.AppendFormat("\"mpvideo\":{{{0}}},", JsonHelper.WriteObject("media_id", this.ContentOrMediaId));
						sb.AppendFormat("\"msgtype\":\"mpvideo\"");
						break;
					case WeChatMessageTypes.VOICE:
						sb.AppendFormat("\"voice\":{{{0}}},", JsonHelper.WriteObject("media_id", this.ContentOrMediaId));
						sb.AppendFormat("\"msgtype\":\"voice\"");
						break;
				}

				sb.Append("}");
				return sb.ToString();
			}
		}
	}
}
