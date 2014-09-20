using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Response
{
    public class SendTemplateResponse : AbstractResponse
    {
        public long msgid { get; set; }
    }
}
