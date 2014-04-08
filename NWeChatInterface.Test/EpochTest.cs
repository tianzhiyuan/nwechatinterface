using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace NWeChatInterface.Test
{
    [TestFixture]
    public class EpochTest
    {

        [TestCase(1396516496, "2014年4月3日 下午5:14:56")]
        [TestCase(1388509200, "2014年1月1日 上午1:00:00")]
        public void EpochToDateTimeTest(long epoch, string expect)
        {
            var converted = Epoch.ConvertToLocalTime(epoch);
            var expected = DateTime.Parse(expect);
            Assert.AreEqual(converted, expected);
        }
        [TestCase("2014年4月3日 下午5:14:56", 1396516496)]
        [TestCase("2014年1月1日 上午1:00:00", 1388509200)]
        public void DateTimeToEpochTest(string time, long expect)
        {
            Assert.AreEqual(Epoch.ConvertToEpoch(DateTime.Parse(time)), expect);
        }
    }
}
