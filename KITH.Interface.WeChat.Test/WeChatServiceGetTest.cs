using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KITH.Interface.WeChat.Requests;
using NUnit.Framework;
namespace KITH.Interface.WeChat.Test
{
    [TestFixture]
    class WeChatServiceGetTest
    {
        WeChatService Service = WeChatTestCaseSupplier.Service;
        private string TempAT = WeChatTestCaseSupplier.TempAccessToken;
        private string SomeOpenId = WeChatTestCaseSupplier.SomeFanOpenId;
        /// <summary>
        /// 运行其它测试前先调试该测试并获得AccessToken，记录到TestCaseSupplier.TempAccessToken中，方便进行其他测试
        /// </summary>
        [Test]
        public void GetAccessToken()
        {
            var svc = WeChatTestCaseSupplier.Service;
            var ret = svc.Get(new GetAccessToken(WeChatTestCaseSupplier.SomeAppKey, WeChatTestCaseSupplier.SomeAppSecret));
            Assert.AreEqual(ret.errcode, 0);

        }
        [Test]
        public void GetMenu()
        {
            var svc = WeChatTestCaseSupplier.Service;
            var obj = svc.Get(new GetMenu(WeChatTestCaseSupplier.TempAccessToken));
            Assert.AreEqual(obj.errcode, 0);
        }

        [TestCase(1, GetQRTicket.PermanentQR, 0)]
        [TestCase(2, GetQRTicket.PermanentQR, 0)]
        [TestCase(GetQRTicket.PermantQRSecenId_MAX, GetQRTicket.PermanentQR, 0)]
        [TestCase(1, GetQRTicket.TempQR, 1000)]
        [TestCase(2, GetQRTicket.TempQR, 1000)]
        [TestCase(100000, GetQRTicket.TempQR, 1000)]
        public void GetQRTicketWithNoException(int sceneid, string actionName, int expire)
        {
            var obj = Service.Get(new GetQRTicket(TempAT, sceneid, actionName, expire));
            Assert.AreEqual(obj.errcode, 0);
        }
        [Test]
        public void GetPermanentQRTicketWithSameSceneIdAndTicketAreSame()
        {
            var obj = Service.Get(new GetQRTicket(TempAT, 100, GetQRTicket.PermanentQR, 300));
            var obj2 = Service.Get(new GetQRTicket(TempAT, 100, GetQRTicket.PermanentQR, 300));
            Assert.AreEqual(obj.ticket, obj2.ticket);
        }
        [Test]
        public void GeTempQRTicketWithSameSceneIdAndTicketAreDifferent()
        {
            var obj = Service.Get(new GetQRTicket(TempAT, 100, GetQRTicket.TempQR, 300));
            var obj2 = Service.Get(new GetQRTicket(TempAT, 100, GetQRTicket.TempQR, 300));
            Assert.AreNotEqual(obj.ticket, obj2.ticket);
        }
        [Test]
        public void GetSubscriber()
        {
            var obj = Service.Get(new GetSubscribers(TempAT));
            Assert.AreEqual(0, obj.errcode);
        }
        [Test]
        public void GetUserInfo()
        {
            var obj = Service.Get(new GetUserInfo(SomeOpenId, TempAT));
            Assert.AreEqual(0, obj.errcode);
        }
        [Test]
        public void UploadMedia()
        {
            var filename = @"d:\123.jpg";
            var obj =
                Service.UploadMedia(new UploadMedia(TempAT, WeChatMediaType.Image, File.ReadAllBytes(filename),
                                                    "123.jpg"));

        }
    }
}
