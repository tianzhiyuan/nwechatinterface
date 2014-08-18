using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWeChatInterface.Models
{
    /// <summary>
    /// 微信推广二维码
    /// </summary>
    public class QRTicket
    {
        public const string TEMP_QR = "QR_SCENE";
        public const string PERMANENT_QR = "QR_LIMIT_SCENE";
        public const int PERMANENT_QR_SCENE_ID_MAX = 100000;
        /// <summary>
        /// 如果二维码类型为临时二维码<see cref="TEMP_QR"/>，表示该二维码的有效时间
        /// </summary>
        public int expire_seconds { get; set; }
        /// <summary>
        /// 二维码类型包括临时<see cref="TEMP_QR"/>和永久<see cref="PERMANENT_QR"/>，其中永久编号从1-100000
        /// </summary>
        public string action_name { get; set; }
        /// <summary>
        /// 场景值ID
        /// </summary>
        public int scene_id { get; set; }
    }
}
