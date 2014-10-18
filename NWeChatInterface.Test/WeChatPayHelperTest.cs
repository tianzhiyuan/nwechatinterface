using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NWeChatPay;

namespace NWeChatInterface.Test
{
    [TestFixture]
    public class WeChatPayHelperTest
    {
        [Test]
        public void TestParse()
        {
            var source = @"<xml><OpenId><![CDATA[oDF3iY9P32sK_5GgYiRkjsCo45bk]]></OpenId><AppId><![CDATA[wxf8b4f85f3a794e77]]></AppId> 
<TimeStamp>1393400471</TimeStamp> 
<MsgType><![CDATA[request]]></MsgType> 
<FeedBackId>7197417460812502768</FeedBackId> 
<TransId><![CDATA[1900000109201402143240185685]]></TransId> 
<Reason><![CDATA[质量问题]]></Reason> 
<Solution><![CDATA[换货]]></Solution> 
<ExtInfo><![CDATA[备注 12435321321]]></ExtInfo> 
<AppSignature> 
<![CDATA[d60293982cc7c97a5a9d3383af761db763c07c86]]></AppSignature> 
<SignMethod> 
<![CDATA[sha1]]> 
</SignMethod> 
<PicInfo> 
<item><PicUrl><![CDATA[http://mmbiz.qpic.cn/mmbiz/49ogibiahRNtOk37iaztwmdgFbyFS9FU
rqfodiaUAmxr4hOP34C6R4nGgebMalKuY3H35riaZ5vtzJh25tp7vBUwWxw/0]]></PicUrl> 
</item> 
<item> 
<PicUrl> 
<![CDATA[http://mmbiz.qpic.cn/mmbiz/49ogibiahRNtOk37iaztwmdgFbyFS9FUrqfn3y72eHKRS
AwVz1PyIcUSjBrDzXAibTiaAdrTGb4eBFbib9ibFaSeic3OIg/0]]></PicUrl> 
</item> 
<item> 
<PicUrl> 
<![CDATA[]]></PicUrl></item><item><PicUrl><![CDATA[]]></PicUrl></item><item><PicUrl
><![CDATA[]]></PicUrl></item></PicInfo></xml>";
            var source2 = @"<xml> 
 <OpenId><![CDATA[111222]]></OpenId> 
 <AppId><![CDATA[wwwwb4f85f3a797777]]></AppId> 
 <TimeStamp> 1369743511</TimeStamp> 
 <MsgType><![CDATA[confirm]]></MsgType> 
 <FeedBackId><![CDATA[5883726847655944563]]></FeedBackId> 
 <Reason><![CDATA[商品质量有问题]]></Reason> 
 <AppSignature><![CDATA[bafe07f060f22dcda0bfdb4b5ff756f973aecffa]]> 
 </AppSignature> 
 <SignMethod><![CDATA[sha1]]></SignMethod> 
</xml> ";
            var obj = new WeChatPayHelper().ParsePayFeedback(source);
            var obj2 = new WeChatPayHelper().ParsePayFeedback(source2);

        }
        [Test]
        public void testnativeurl()
        {
            var param = new NativePayParam()
                {
                    AppId = "wxf8b4f85f3a794e77",
                    AppKey =
                        "2Wozy2aksie1puXUBpWD8oZxiD1DfQuEaiC7KcRATv1Ino3mdopKaPGQQ7TtkNySuAmCaDCrw4xhPY5qKTBl7Fzm0RgR3c0WaVYIXZARsxzHV2x7iwPPzOz94dnwPWSn",
                    ProductId = "123456",
                    NonceStr = "adssdasssd13d"
                };
            var url = new WeChatPayHelper().CreateNativePayUrl(param);
        }
    }
}
