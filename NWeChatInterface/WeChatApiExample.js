//隐藏微信网页右上角按钮
//公众号在有需要时（如不需要用户分享某个页面），可在网页中通过JavaScript代码隐藏网页右上角按钮
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    WeixinJSBridge.call('hideOptionMenu');
});

//显示微信网页右上角按钮
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    WeixinJSBridge.call('showOptionMenu');
});

//隐藏微信中网页底部导航栏
//公众号在有需要时（如认为用户在该页面不会用到浏览器前进后退功能），可在网页中通过JavaScript代码隐藏网页底部导航栏。
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    WeixinJSBridge.call('hideToolbar');
});

//显示微信网页底部导航栏
document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
    WeixinJSBridge.call('showToolbar');
});


//网页获取用户网络状态
//为了方便开发者根据用户的网络状态来提供不同质量的服务，公众号可以在公众号内部的网页中使用JavaScript代码调用来获取网络状态。
WeixinJSBridge.invoke('getNetworkType', {},
        function (e) {
            switch (e.err_msg) {
                case 'network_type:wifi'://wifi网络
                    break;
                case 'network_type:edge'://非wifi,包含3G/2G
                    break;
                case 'network_type:fail'://网络断开连接
                    break;
                case 'network_type:wwan'://2g或者3g）
                    break;
            }
        });

