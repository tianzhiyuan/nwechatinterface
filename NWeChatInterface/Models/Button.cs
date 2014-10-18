using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Models
{
    /// <summary>
    /// 微信自定义菜单类型
    /// </summary>
    public class ButtonTypes
    {
        /// <summary>
        /// 点击
        /// </summary>
        public const string Click = "click";
        public const string View = "view";
    }
    /// <summary>
    /// 微信自定义菜单按钮
    /// </summary>
    public class Button
    {
        public string name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        public string url { get; set; }
        public string key { get; set; }
        /// <summary>
        /// 生成带有微信OAuth接口的Url
        /// </summary>
        /// <param name="appid">appid</param>
        /// <param name="u">原Url</param>
        public void SetUrlWithAuth(string appid, string u)
        {
            this.url = WeChatOAuthBuilder.BuildBaseUrl(appid, u);
        }
        public Button[] sub_button { get; set; }
    }
   
}
