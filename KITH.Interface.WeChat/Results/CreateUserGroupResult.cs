using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;

namespace NWeChatInterface.Results
{
    public class CreateUserGroupResult:AbstractResult
    {
        public UserGroup group { get; set; }
    }
}
