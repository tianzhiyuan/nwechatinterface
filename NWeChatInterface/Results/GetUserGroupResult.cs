using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Results
{
    public class GetUserGroupResult:AbstractResult
    {
        public UserGroup[] groups { get; set; }
    }
}
