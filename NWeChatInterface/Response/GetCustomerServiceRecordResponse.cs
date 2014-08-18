using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Response
{
    public class GetCustomerServiceRecordResponse : WeChatResponse
    {
        public CustomerServiceRecord[] recordlist { get; set; }
    }
}
