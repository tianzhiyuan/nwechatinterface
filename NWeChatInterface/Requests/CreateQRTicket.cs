using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using NWeChatInterface.Response;

namespace NWeChatInterface.Requests
{
    /// <summary>
    /// 创建推广二维码
    /// 
    /// 目前有2种类型的二维码，分别是临时二维码和永久二维码，
    /// 前者有过期时间，最大为1800秒，但能够生成较多数量，后者无过期时间，数量较少（目前参数只支持1--100000）。
    /// 两种二维码分别适用于帐号绑定、用户来源统计等场景。
    /// 
    /// 用户扫描带场景值二维码时，可能推送以下两种事件：
    /// 如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
    /// 如果用户已经关注公众号，在用户扫描后会自动进入会话，微信也会将带场景值扫描事件推送给开发者。
    /// 
    /// 获取带参数的二维码的过程包括两步，首先创建二维码ticket，然后凭借ticket到指定URL换取二维码。
    /// 
    /// https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=TICKET 获取二维码图片
    /// </summary>
    public class CreateQRTicket : IPostRequest<QRTicketResponse>
    {
        public const string TempQR = "QR_SCENE";
        public const string PermanentQR = "QR_LIMIT_SCENE";
        public const int PermantQRSecenId_MAX = 100000;
        public string AccessToken { get; private set; }
        public QRTicket QRTicket { get; private set; }
        public CreateQRTicket(string accessToken, int scene_id, string actionName = PermanentQR, int expire = 1800)
        {
            this.QRTicket = new QRTicket();
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
                this.QRTicket.expire_seconds = expire;
            }
            else
            {
                if (scene_id > PermantQRSecenId_MAX)
                {
                    throw new ArgumentException("scene_id larger than max");
                }
            }
            this.QRTicket.action_name = actionName;
            this.QRTicket.scene_id = scene_id;
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

        public string Data
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("{");
                if (this.QRTicket.action_name == QRTicket.TEMP_QR)
                {
                    sb.AppendFormat("'expire_seconds':{0},", this.QRTicket.expire_seconds);
                }
                sb.AppendFormat("'action_name':'{0}',", this.QRTicket.action_name);
                sb.AppendFormat("'action_info':{{'scene':{{'scene_id':{0}}}}}", this.QRTicket.scene_id);
                sb.Append("}");
                sb.Replace(',', '\"');
                return sb.ToString();
            }
        }
    }
}
