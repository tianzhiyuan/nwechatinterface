﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Response;
using Newtonsoft.Json;

namespace NWeChatInterface.Requests
{
	public class CreateKfAccount : IPostRequest<CommonResponse>
	{
		[JsonIgnore]
		public string AccessToken { get; private set; }
		[JsonProperty("kf_account")]
		public string KfAccount { get; private set; }
		[JsonProperty("nickname")]
		public string NickName { get; private set; }
		[JsonProperty("password")]
		public string Password { get; private set; }
		public CreateKfAccount(string accessToken, string account, string nickname, string password)
		{
			this.AccessToken = accessToken;
			this.KfAccount = account;
			this.NickName = nickname;
			this.Password = password;
		}
		public string RequestUrl { get { return string.Format("https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}", AccessToken); } }
		public string Data { get { return JsonConvert.SerializeObject(this); } }
	}
}
