document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    //{}可以使用后台WeChatPayHelper.CreateJSApiParam()函数生成
    WeixinJSBridge.invoke('getBrandWCPayRequest', {}, function (res) {
        if (res.err_msg == "get_brand_wcpay_request:ok") {
            //支付成功逻辑
        }
        else {
            //支付失败
        }
    });
});