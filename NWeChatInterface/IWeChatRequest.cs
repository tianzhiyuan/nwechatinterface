using Newtonsoft.Json;

namespace NWeChatInterface
{
    /// <summary>
    /// marker interface
    /// </summary>
    [RequestMethod(RequestMethod.GET)]
	[RequestPath("")]
    public interface IWeChatRequest
    {
        [JsonIgnore]
        string Param { get; }
		[JsonIgnore]
		string Data { get; }
        //bool Validate();
    }
    public interface IWeChatRequest<TResponse> : IWeChatRequest where TResponse :  AbstractResponse
    {
        
    }
}
