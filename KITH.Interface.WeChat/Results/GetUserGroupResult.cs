using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KITH.Interface.WeChat.Models;

namespace KITH.Interface.WeChat.Results
{
    public class GetUserGroupResult:AbstractResult
    {
        public UserGroup[] groups { get; set; }
    }
}
