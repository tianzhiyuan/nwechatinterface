using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NWeChatInterface.Models
{
	public class KfAccount
	{
		/// <summary>
		/// 完整客服账号，格式为：账号前缀@公众号微信号
		/// </summary>
		[JsonProperty("kf_account")]
		public string Account { get; set; }
		/// <summary>
		/// 客服昵称
		/// </summary>
		[JsonProperty("kf_nick")]
		public string NickName { get; set; }
		/// <summary>
		/// 客服工号
		/// </summary>
		[JsonProperty("kf_id")]
		public string Id { get; set; }
		/// <summary>
		/// 头像
		/// </summary>
		[JsonProperty("kf_headimg")]
		public string Headimg { get; set; }
		/// <summary>
		/// 客服在线状态 1：pc在线，2：手机在线。若pc和手机同时在线则为 1+2=3
		/// </summary>
		[JsonProperty("status")]
		public int Status { get; set; }
		/// <summary>
		/// 客服设置的最大自动接入数
		/// </summary>
		[JsonProperty("auto_accept")]
		public int AutoAccecpt { get; set; }
		/// <summary>
		/// 客服当前正在接待的会话数
		/// </summary>
		[JsonProperty("accepted_case")]
		public int AcceptedCase { get; set; }
	}
}
