using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using NWeChatInterface.Requests;
using NUnit.Framework;
using NWeChatInterface.Requests.Menu;
using NWeChatInterface.Requests.Message;
using NWeChatInterface.Requests.User;
using NWeChatInterface.ResponseMessages;

namespace NWeChatInterface.Test
{
    [TestFixture]
    public class WeChatServiceTest
    {
        private readonly IWeChatService wechat = new WeChatService();
        private string someAppKey = ConfigurationManager.AppSettings["AppId"];
        private string someAppSecret = ConfigurationManager.AppSettings["AppSecret"];
		private string tempToken = "O9nUnG3siW_rhjGNk86ecUmDtsyzKtlbIauOo22QHuV2Q7uoxXMNH33QcRiHNCt9qVuVm-1IdLsxnu_cmxwfRujugh1ioIKNXv7NKu6_xs8";
		private string tempOpenId = "onVystwzSY2HXb2Qs-56aSl6a5mE";

        [Test]
        public void VerifySignatureTest()
        {
            string token = "weixin";
            string timestamp = "1413266687";
            string nonce = "698130451";
            string signature = "f18126274f9a7023bb01ad8e397e47cab3b9c250";
            bool result = wechat.VerifySignature(nonce, timestamp, token, signature);
            Assert.True(result);
        }
        /// <summary>
        /// 运行其它测试前先调试该测试并获得AccessToken，方便进行其他测试
        /// </summary>
        [Test]
        public void GetAccessToken()
        {
            var svc = wechat;
            var ret = svc.Execute(new GetAccessToken(someAppKey, someAppSecret));
            Console.WriteLine(ret);
            Assert.AreEqual(ret.errcode, 0);

        }
        [Test]
        public void GetMenu()
        {
            var svc = wechat;
            var obj = svc.Execute(new GetMenu(){AccessToken = tempToken});
            Console.WriteLine(obj);
            Assert.AreEqual(obj.errcode, 0);
        }

        [TestCase(1, CreateQRTicket.PermanentQR, 0)]
        [TestCase(CreateQRTicket.PermantQRSecenId_MAX, CreateQRTicket.PermanentQR, 0)]
        [TestCase(200000, CreateQRTicket.TempQR, 1000)]
        public void GetQRTicketWithNoException(int sceneid, string actionName, int expire)
        {
            var obj = wechat.Execute(new CreateQRTicket(tempToken, sceneid, actionName, expire));
            Console.WriteLine(obj);
            Assert.AreEqual(obj.errcode, 0);
        }
        [Test]
        public void CreateMenuTest()
        {
            var menu = new Menu();
            menu.button = new Button[]
                {
                    new Button(){name = "Tencent", type = ButtonTypes.View, url = "http://www.qq.com"}, 
                    new Button(){name = "ClickMe", type = ButtonTypes.Click, key = "temp"},
                    new Button(){name = "Parent", sub_button = new Button[]
                        {
                            new Button(){name = "Wechat", type = ButtonTypes.View, url = "http://weixin.qq.com"}
                        }}
                };
            var response = wechat.Execute(new CreateMenu(){AccessToken = tempToken, Menu = menu});
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
        [Test]
        public void GetPermanentQRTicketWithSameSceneIdAndTicketAreSame()
        {
            var obj = wechat.Execute(new CreateQRTicket(tempToken, 100, CreateQRTicket.PermanentQR, 300));
            var obj2 = wechat.Execute(new CreateQRTicket(tempToken, 100, CreateQRTicket.PermanentQR, 300));
            Assert.AreEqual(obj.ticket, obj2.ticket);
        }
        [Test]
        public void GeTempQRTicketWithSameSceneIdAndTicketAreDifferent()
        {
            var obj = wechat.Execute(new CreateQRTicket(tempToken, 100, CreateQRTicket.TempQR, 300));
            var obj2 = wechat.Execute(new CreateQRTicket(tempToken, 100, CreateQRTicket.TempQR, 300));
            Assert.AreNotEqual(obj.ticket, obj2.ticket);
        }
        [Test]
        public void GetSubscriber()
        {
            var obj = wechat.Execute(new GetSubscribers(tempToken));
            Console.WriteLine(obj);
            foreach (var openid in obj.data.openid)
            {
                Console.WriteLine(openid);
            }
            
            Assert.AreEqual(0, obj.errcode);
        }
		[TestCase("onVystwzSY2HXb2Qs-56aSl6a5mE")]
        public void GetUserInfo(string openid)
        {
            var obj = wechat.Execute(new GetUserInfo(){OpenId = openid, AccessToken = tempToken});
            Console.WriteLine(obj);
            Assert.AreEqual(0, obj.errcode);
        }
        [Test]
        public void UploadMedia()
        {
            var filename = @"d:\test.jpg";
            var obj =
                wechat.Execute(new UploadMedia(tempToken, WeChatMediaType.IMAGE, File.ReadAllBytes(filename),
                                                    "123.jpg"));
            Console.WriteLine(obj);
            Assert.AreEqual(0, obj.errcode);

        }
        [Test]
        public void CreateShortUrlTest()
        {
            var response = wechat.Execute(new CreateShortUrl(tempToken, "https://mp.weixin.qq.com/cgi-bin/contactmanage?t=user/index&pagesize=10&pageidx=1&type=0&token=1222040332&lang=zh_CN"));
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
        [Test]
        public void GetUserBelongGroupTest()
        {
            var response = wechat.Execute(new GetBelongUserGroup(){AccessToken = tempToken, OpenId = tempOpenId});
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
        [Test]
        public void SendCustomerServiceMessage_Text()
        {
            var response =
                wechat.Execute(new SendCustomerServiceMessage(){AccessToken = tempToken, Message = new TextMessage()
                                                                  {
                                                                      Content = "测试客服文本消息",
                                                                      ToUserName = tempOpenId,
                                                                      CreatedAt = DateTime.Now
                                                                  }});
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
        [Test]
        public void SendMassMessage_Text()
        {
            var response =
				wechat.Execute(new SendMassMessageByOpenId() { AccessToken = tempToken, UserIds = new string[] { tempOpenId }, ContentOrMediaId = "测试群发消息", Type = WeChatMessageTypes.TEXT });
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
        [Test]
        public void SetUserRemarkTest()
        {
            var response = wechat.Execute(new SetUserRemark(){AccessToken = tempToken, OpenId = tempOpenId, Remark = "tt"});
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
    }
}
