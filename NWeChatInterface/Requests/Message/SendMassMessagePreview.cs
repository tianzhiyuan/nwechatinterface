using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests.Message
{
	/// <summary>
	/// 开发者可通过该接口发送消息给指定用户，在手机端查看消息的样式和排版。
	/// </summary>
	public class SendMassMessagePreview : AccessRequiredRequest<SendMassMessageResponse>
	{
		/// <summary>
		/// 消息类型，包括语音voice,图片image，文本text，多图文news，视频video<see cref="WeChatMessageTypes"/>
		/// </summary>
		public string Type { get; set; }

		public string OpenId { get; set; }
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

				sb.AppendFormat("\"touser\":\"{0}\",", OpenId);

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
