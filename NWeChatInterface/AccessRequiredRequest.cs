using Newtonsoft.Json;

namespace NWeChatInterface
{
	public abstract class AccessRequiredRequest<TResponse> : IWeChatRequest<TResponse> where TResponse : AbstractResponse
	{
		/// <summary>
		/// 公众号接口访问票据
		/// </summary>
		[JsonIgnore]
		public string AccessToken { get; set; }
		[JsonIgnore]
		public virtual string Param { get { return string.Format("access_token={0}", AccessToken); } }
		[JsonIgnore]
		public virtual string Data { get { return ""; } }
		
		protected string SerializeJson(object obj)
		{
			return JsonConvert.SerializeObject(obj,
			                                   new JsonSerializerSettings()
				                                   {
					                                   NullValueHandling = NullValueHandling.Ignore,
					                                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
				                                   });
		}
	}
}
