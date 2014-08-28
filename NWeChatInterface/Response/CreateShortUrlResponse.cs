using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
    public class CreateShortUrlResponse : AbstractResponse
    {
        public string short_url { get; set; }
    }
}
