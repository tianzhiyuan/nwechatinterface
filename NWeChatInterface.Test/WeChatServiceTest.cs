using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NWeChatInterface.Models;
using NWeChatInterface.Requests;
using NUnit.Framework;
namespace NWeChatInterface.Test
{
    [TestFixture]
    public class WeChatServiceTest
    {
        private readonly IWeChatService wechat = new WeChatService();
        private string someAppKey = "";
        private string someAppSecret = "";
        private string tempToken = "GFreFKH0o7qiLyfqJDog8bxzd_kPBcloQcHBwBvop4GFZStCN0-Fy2biQZzT01pxEfPhUdBB1vNoMuY1LHF9ge6ISeVzWVZzEgf8fj6gsAU";
        private string tempOpenId = "ob0Yssym8ndt--BDOgIEZucfyipQ";

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
            var svc = WeChatTestCaseSupplier.Service;
            var ret = svc.Execute(new GetAccessToken(someAppKey, someAppSecret));
            Console.WriteLine(ret);
            Assert.AreEqual(ret.errcode, 0);

        }
        [Test]
        public void GetMenu()
        {
            var svc = wechat;
            var obj = svc.Execute(new GetMenu(tempToken));
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
            var response = wechat.Execute(new CreateMenu(tempToken, menu));
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
        [TestCase("ob0Yss3q_2hKYB2Rz9t4rEB-2ByI")]
        [TestCase("ob0Yss8LQtzpA_Vmm0qtAhrNe36U")]
        [TestCase("ob0Yss9IViTXFQopqMr1Fc-CDlRk")]
        [TestCase("ob0Yss002wYHtMu57TKYBRLoFUtA")]
        [TestCase("ob0Yss676OJrVjlI7EjjQY-bx-jo")]
        [TestCase("ob0Yss6pGhEYd8TkEHTgLH5_VHnU")]
        [TestCase("ob0YssxWU0ffm8TQAHedA2kWbVA4")]
        [TestCase("ob0Yssym8ndt--BDOgIEZucfyipQ")]
        [TestCase("ob0Yss7SyO5ZB1me5xBplA3TB4Bg")]
        [TestCase("ob0Yss10rtb1WAL29qG6x2SbtiZY")]
        public void GetUserInfo(string openid)
        {
            var obj = wechat.Execute(new GetUserInfo(openid, tempToken));
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
            var response = wechat.Execute(new GetBelongUserGroup(tempToken, tempOpenId));
            Console.WriteLine(response);
            Assert.AreEqual(0, response.errcode);
        }
    }
}
