﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Results
{
    /// <summary>
    /// OpenId结果 
    /// </summary>
    public class GetOpenIdResult : AbstractResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string openid { get; set; }
        public string scope { get; set; }
    }
}
