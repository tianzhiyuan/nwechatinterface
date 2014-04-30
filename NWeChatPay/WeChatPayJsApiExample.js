//JS 支付样例
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

//收货地址共享接口示例
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    //{} 可以使用WeChatPayHelper.CreateAddressParam()生成 
    WexinJSBridge.invoke('editAddress', {}, function(res) {
        if (res && res.err_msg == "edit_address:ok") {
            var addr1 = res.proviceFirstStageName; //国标收货地址第一级地址(PS:严重怀疑微信开发人员英文0.0)
            var addr2 = res.addressCitySecondStageName; //国标收货地址第二级地址
            var addr3 = res.addressCountiesThirdStageName; //国标收货地址第三级地址
            var detail = res.addressDetailInfo; //详细收货地址信息
            var username = res.userName; //收货人姓名
            var mobile = res.telNumber; //收货人电话
        }

    });
});