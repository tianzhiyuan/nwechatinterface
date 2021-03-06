﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface
{
    public abstract class AbstractResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public override string ToString()
        {
            var type = this.GetType();
            var properties = type.GetProperties().Where(o => o.Name != "errcode" || o.Name != "errmsg");
            var sb = new StringBuilder();
            foreach (var property in properties)
            {
                sb.AppendFormat("{0}:{1}, ", property.Name, property.GetValue(this, null));
            }
            return sb.ToString();
        }
    }
}
