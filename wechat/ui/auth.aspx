<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="" Inherits="" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>测试</title>
    
    <link href="Content/css/index.css" rel="stylesheet" />
    <script src="https://res.wx.qq.com/open/js/jweixin-1.4.0.js" type="text/javascript"></script>
    <script src="Content/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">  
        var m_timeStamp = "";
        var m_nonceStr = "";
        var m_mypackage = "";
        var m_sign = "";

        $(document).ready(function ()
        {
            //从浏览器取code参数
            var code = getQueryString("code");
            if (code == null)
            {
                $.ajax({
                    url: "/Ajax/AjaxWechat.ashx",
                    type: "POST",
                    data: { "type": "init" },
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.msg == "200") {
                            //取到code重定向
                            location.href = data.data;
                        }
                    }
                });
            }
            else
            {
                $.ajax({
                    url: "/Ajax/AjaxWechat.ashx",
                    type: "POST",
                    data: { "type": "sign", "code": code },
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        if (data.msg == "200") {
                            //初始化
                            wx.config({
                                //debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                                appId: data.appId, // 必填，公众号的唯一标识
                                timestamp: data.timeStamp, // 必填，生成签名的时间戳
                                nonceStr: data.nonceStr, // 必填，生成签名的随机串
                                signature: data.sha1sign,// 必填，签名，SHA1
                                jsApiList: ['chooseWXPay'] // 必填，需要使用的JS接口列表
                            });
                        }
                    }
                });
            }          
            
            $('#submit').click(function (event) {
                var data = $('#userId').val();
                var patt = /^(0?(13|14|15|16|17|18|19)[0-9]{9})$/;
                if (!patt.test(data)) {
                    $('#error').show();
                    event.preventDefault();
                    document.getElementById("userId").focus();
                }
                else {
                    $('#error').hide();
                    createBill();
                }
            });

            //隐藏页面元素
            $('#error').hide();             
        });

        function createBill()
        {
            //从输入框取出手机号
            var mobile = $('#userId').val();
            //从浏览器取code参数
            var code = getQueryString("code");

            //测试
            $.ajax({
                url: "/Ajax/AjaxWechat.ashx",
                type: "POST",
                data: { "type": "pay", "mobile": mobile, "code": code },
                async: false,
                dataType: "json",
                success: function (data) {
                    if (data.msg == "200") {
                        wx.chooseWXPay({
                            timestamp: data.timeStamp, // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                            nonceStr: data.nonceStr, // 支付签名随机串，不长于 32 位
                            package: data.mypackage, // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=\*\*\*）
                            signType: "MD5", // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                            paySign: data.md5sign, // 支付签名
                            success: function (res) {
                                // 支付成功后的回调函数
                                if (res.errMsg === 'chooseWXPay:ok') {
                                    alert("ok");
                                }
                            }
                        });
                    }
                    else {
                        alert("创建订单失败");
                    }
                }
                ,error: function (XMLHttpRequest, textStatus, errorThrown)
                {
                    // 状态码
                    alert(XMLHttpRequest.status); //200
                    // 状态
                    alert(XMLHttpRequest.readyState); //4
                    // 错误信息   
                    alert(textStatus); //parserError
                }
            });
        }

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    </script> 
</head>

 
<body>
<form id="signup" method="post" action="">  
    <div class="mainbg">
        <div class="header">
            商品            
        </div>

        <div class="main">
            <div class="logo">
                <img src="" />
            </div>

            <div class="fromj">
               <div class="tel">
                   <img src="" />
               </div>
              <div class="inputf"><input type="number" id="userId" name="userId" placeholder="请输入手机号码" oninput="if(value.length>11) value=value.slice(0,11)"/></div>
              <div id="error" class="yz">* 手机号码不能为空</div>
            
            
              <div class="ytitel">商品</div>
                 <ul class="ytitelul">
                     <li>描述</li>
                     <li>描述</li>
                     <li>描述</li>
                 </ul>
                 
            </div>
            <div class="yushou">
                <span><s>原价XXX元</s></span>
                <span class="ys99">XXX元</span>
            </div>

            <div class="btn_bg">
                <button id="submit"  class="ljbtn">立即支付</button>
            </div>
        </div>

        <div class="content">
            &nbsp;&nbsp; &nbsp;&nbsp; 
            描述描述
          <div class="conbg"></div>
        </div>        
    </div>
</form>
</body>
</html>
