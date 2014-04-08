using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KITH.Interface.WeChat.Models
{
    /// <summary>
    /// 微信推广二维码
    /// </summary>
    public class QRTicket
    {
        public const string TempQR = "QR_SCENE";
        public const string PermanentQR = "QR_LIMIT_SCENE";
        public const int PermantQRSecenId_MAX = 100000;
        /// <summary>
        /// 如果二维码类型为临时二维码<see cref="TempQR"/>，表示该二维码的有效时间
        /// </summary>
        public int expire_seconds { get; set; }
        /// <summary>
        /// 二维码类型包括临时<see cref="TempQR"/>和永久<see cref="PermanentQR"/>，其中永久编号从1-100000
        /// </summary>
        public string action_name { get; set; }
        /// <summary>
        /// 场景值ID
        /// </summary>
        public int scene_id { get; set; }
    }
}
