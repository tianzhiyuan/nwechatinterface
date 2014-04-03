using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Test
{
    public class WeChatTestCaseSupplier
    {
        public const string SomeAppKey = "";
        public const string SomeAppSecret = "";
        public const string SomeFanOpenId = "";
        private static WeChatService _instance;
        public static WeChatService Service
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new WeChatService();
                }
                return _instance;
            }
        }

        public static string TempAccessToken =
            "";
    }
}
