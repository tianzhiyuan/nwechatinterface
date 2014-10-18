using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NWeChatPay;

namespace NWeChatInterface.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            int a = 10;
            int b = 11;
            int result = AddTwoNumber(a, b);
            Assert.AreEqual(result, 21);
        }
        [Test]
        public void Test2()
        {
            int a = 0;
            int b = 1;
            int result = AddTwoNumber(a, b);
            Assert.AreEqual(result, 1);
        }
        [TestCase(1,2,3)]
        [TestCase(2,3,5)]
        public void TestCase(int a, int b, int result)
        {
            Assert.AreEqual(AddTwoNumber(a, b), result);
            
        }
        public int AddTwoNumber(int a, int b)
        {
            
            return a + b;
        }
        public void StrFunc(string str)
        {
            
        }
        [Test]
        public void paytest()
        {
            var helper = new WeChatPayHelper();
            var api = new JSApiParam()
                {
                    AppId = "appid",
                    AppKey = "2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn",
                    Body = "我勒个去",
                    ClientIp = "192.168.1.1",
                    NotifyUrl = "http://localhost:5500/pay/paycallback",
                    OutTradeNo = "outtradeno",
                    Partner = "partner",
                    PartnerKey = "partnerkey",
                    TotalFee = 1,

                };
            var str = helper.CreateJSApiParam(api);
        }
        [Test]
        public void TestHash()
        {
            var hash = WeChatPayHelper.Hash(
                @"bank_type=WX&body=支付测试&fee_type=1&input_charset=UTF-8&notify_url=http://weixin.qq.com&out_trade_no=7240b65810859cbf2a8d9f76a638c0a3&partner=1900000109&spbill_create_ip=196.168.1.1&total_fee=1&key=8934e7d15453e97507ef794cf7b0519d", "MD5");
            Assert.AreEqual(hash.ToUpper(), "7F77B507B755B3262884291517E380F8");
        }
    }

}
