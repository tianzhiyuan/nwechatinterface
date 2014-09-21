using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Models
{
    public class TemplateMessage
    {
        public string to_user { get; set; }
        public string template_id { get; set; }
        public string url { get; set; }
        public string topcolor { get; set; }
        public dynamic data { get; set; }
    }
}
