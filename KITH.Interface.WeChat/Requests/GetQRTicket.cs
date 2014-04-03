using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KITH.Interface.WeChat.Results;

namespace KITH.Interface.WeChat.Requests
{
    /// <summary>
    /// 获取推广二维码
    /// </summary>
    public class GetQRTicket : IPostRequest<QRTicketResult>
    {
        public const string TempQR = "QR_SCENE";
        public const string PermanentQR = "QR_LIMIT_SCENE";
        public const int PermantQRSecenId_MAX = 100000;

        public int expire_seconds { get; private set; }
        public string action_name { get; private set; }
        public dynamic action_info { get; private set; }
        public string AccessToken { get; private set; }

        public GetQRTicket(string accessToken, int scene_id, string actionName = PermanentQR, int expire = 1800)
        {
            if (actionName != TempQR && actionName != PermanentQR)
            {
                throw new ArgumentException("action_name must be QR_SCENE or QR_LIMIT_SCENE");
            }
            if (scene_id <= 0)
            {
                throw new ArgumentException("scene id must larger than 0");
            }
            if (actionName == TempQR)
            {
                if (expire <= 30 || expire > 1800)
                {
                    throw new ArgumentException(string.Format("expire seconds must between 30-1800"));
                }
                this.expire_seconds = expire;
            }
            else
            {
                if (scene_id > PermantQRSecenId_MAX)
                {
                    throw new ArgumentException("scene_id larger than max");
                }
            }
            this.action_name = actionName;
            this.action_info = new {scene = new {scene_id = scene_id}};
            this.AccessToken = accessToken;
        }

        public string RequestUrl
        {
            get
            {
                return string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}",
                                     this.AccessToken);
            }
        }
    }
}
