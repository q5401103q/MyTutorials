using DDit.Component.Tools;
using DDit.Component.Tools.Wechat;
using DDit.Core.Data.Entity.CoreEntity;
using DDit.Core.Data.Entity.MessageEntity;
using DDit.Core.Data.Repository.Repositories.CoreRepositories;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using DDit.Core.Data.Entity.SystemEntity;

namespace DDit.UserCenter.Ajax
{
    /// <summary>
    /// AjaxWechat 的摘要说明
    /// </summary>
    public class AjaxWechat : BaseHandler, IHttpHandler, IRequiresSessionState
    {
        //统一使用这个NLOG的对象记录日志
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //protected string jsapi_ticket = string.Empty;
        //protected string access_token = string.Empty;
        //protected string prepay_id = string.Empty;
        //protected string md5sign = string.Empty;
        //protected string nonceStr = string.Empty;
        //protected string timestamp = string.Empty;
        //protected string openid = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            string type = Q("type", context);
            switch (type)
            {
                case "init":
                    Initialize(context);
                    break;
                case "pay":
                    UnifiedOrder(context);
                    break;
                case "sign":
                    GetPaySign(context);
                    break;
                default:
                    break;
            }
        }

        private void GetPaySign(HttpContext context)
        {
            //定义统一消息体
            Core.Data.Entity.SystemEntity.MessageModel message = new Core.Data.Entity.SystemEntity.MessageModel();
            //定义请求工具
            HttpGetOrPost httpHelper = new HttpGetOrPost();
            //定义重定向URL
            string redirect_url1 = HttpUtility.UrlEncode("https://www.yuming.com.cn/auth.aspx");
            string redirect_url2 = HttpUtility.UrlEncode("https://www.yuming.com.cn/success.html");

            var jsCode = Q("code", context);
            if (string.IsNullOrEmpty(jsCode))
            {
                message.msg = "0";
                message.data = "";
                context.Response.Write(JsonConvert.SerializeObject(message));
                return;
            }

            #region 第二步，获取openid
            string url2 = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={WechatJSAPIConfig.appid}&secret={WechatJSAPIConfig.appSecret}&code={jsCode}&grant_type=authorization_code";
            /* 正确的json
                {
                "access_token":"ACCESS_TOKEN",
                "expires_in":7200,
                "refresh_token":"REFRESH_TOKEN",
                "openid":"OPENID",
                "scope":"SCOPE" 
                }
                */
            string response2 = httpHelper.HttpGet(url2);

            WechatOAuthResponse oauth = JsonConvert.DeserializeObject<WechatOAuthResponse>(response2);
            if (oauth == null || !string.IsNullOrEmpty(oauth.errcode))
            {
                message.msg = "0";
                message.data = "";
                context.Response.Write(JsonConvert.SerializeObject(message));
            }

            //拿到OPENID
            var openid = oauth.openid;
            context.Session["openid"] = oauth.openid;
            #endregion

            #region 第三步获取access_token
            //注意该access_token与授权access_token不一样
            string url3 = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={WechatJSAPIConfig.appid}&secret={WechatJSAPIConfig.appSecret}";
            string response3 = httpHelper.HttpGet(url3);

            WechatAccessResponse access = JsonConvert.DeserializeObject<WechatAccessResponse>(response3);
            if (access == null || access.errcode != 0)
            {
                message.msg = "0";
                message.data = "";
                context.Response.Write(JsonConvert.SerializeObject(message));
            }

            //拿到OPENID
            string access_token = access.access_token;
            #endregion

            #region 第四步，获取jsapi_ticket
            string url4 = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={access_token}&type=jsapi";
            /* 正确的json
            {
                "errcode":0,
                "errmsg":"ok",
                "ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA",
                "expires_in":7200
            }*/
            string response4 = httpHelper.HttpGet(url4);

            WechatTicketResponse ticket = JsonConvert.DeserializeObject<WechatTicketResponse>(response4);
            if (ticket == null || ticket.errcode != 0)
            {
                message.msg = "0";
                message.data = "";

                context.Response.Write(JsonConvert.SerializeObject(message));
            }

            //记录ticket
            string jsapi_ticket = ticket.ticket;
            #endregion

            string timestamp = WxPayApi.GenerateTimeStamp();
            string nonceStr = WxPayApi.GenerateNonceStr();
            context.Session["timestamp"] = timestamp;
            context.Session["nonceStr"] = nonceStr;

            WxPayData configData = new WxPayData();
            configData.SetValue("jsapi_ticket", jsapi_ticket);
            configData.SetValue("noncestr", nonceStr);
            configData.SetValue("timestamp", timestamp);
            configData.SetValue("url", $"https://www.yuming.com.cn/auth.aspx?code={jsCode}&state=STATE");
            string sha1sign = configData.SHA1Sign();

            var jsBridge = new
            {
                msg = "200",
                appId = WechatJSAPIConfig.appid,
                timeStamp = timestamp,
                nonceStr = nonceStr,
                sha1sign = sha1sign
            };

            string jsApiData = JsonConvert.SerializeObject(jsBridge);

            context.Response.Write(jsApiData);
        }

        private void Initialize(HttpContext context)
        {
            //定义统一消息体
            Core.Data.Entity.SystemEntity.MessageModel message = new Core.Data.Entity.SystemEntity.MessageModel();

            //定义重定向URL
            string redirect_url1 = HttpUtility.UrlEncode("https://i.tax360.com.cn/auth.aspx");

            var jsCode = Q("code", context);

            if (string.IsNullOrEmpty(jsCode))
            {
                #region 第一步，调起授权

                //如果用户同意授权，页面将跳转至 redirect_uri/?code=CODE&state=STATE。
                //code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。
                string url1 = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={WechatJSAPIConfig.appid}&redirect_uri={redirect_url1}&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";

                message.msg = "200";
                message.data = url1;
                context.Response.Write(JsonConvert.SerializeObject(message));
                #endregion            
            }
            else
            {
                message.msg = "0";
                message.data = string.Empty;
                context.Response.Write(JsonConvert.SerializeObject(message));
            }
        }

        /// <summary>
        /// 第一步：用户同意授权，获取code
        /// 第二步：通过code换取网页授权access_token
        /// 第三步：刷新access_token（如果需要）        
        /// 第四步：拉取用户信息(需scope为 snsapi_userinfo)
        /// 第五步：获取openid
        /// 第六步：调用微信统一下单
        /// 第七步：拿到prepay_id
        /// 第八步：构造请求URL
        /// 第九步：唤起微信支付
        /// 第十步：支付成功跳转
        /// </summary>
        /// <param name="context"></param>
        private void UnifiedOrder(HttpContext context)
        {
            //定义统一消息体
            Core.Data.Entity.SystemEntity.MessageModel message = new Core.Data.Entity.SystemEntity.MessageModel();
            //定义请求工具
            HttpGetOrPost httpHelper = new HttpGetOrPost();
            //定义重定向URL
            string redirect_url1 = HttpUtility.UrlEncode("https://www.yuming.com.cn/auth.aspx");
            string redirect_url2 = HttpUtility.UrlEncode("https://www.yuming.com.cn/success.html");
            string ip = context.Request.ServerVariables.Get("Remote_Addr").ToString();

            var jsCode = Q("code", context);
            var mobile = Q("mobile", context);

            if (string.IsNullOrEmpty(jsCode) || string.IsNullOrEmpty(mobile))
            {
                message.msg = "0";
                message.data = "";
                context.Response.Write(JsonConvert.SerializeObject(message));
                return;
            }
            
            try
            {                
                BillRepository service = new BillRepository();
                var bill = service.CreateBill("id", mobile); 
                if (!string.IsNullOrEmpty(bill))
                {
                    //logger.Error("创建订单结果：");
                    //logger.Error(bill);
                    BillAddResponse billData = JsonConvert.DeserializeObject<BillAddResponse>(bill);
                    if (billData != null)
                    {

                        #region 第二步，发起预支付统一下单                 

                        string timestamp = context.Session["timestamp"].ToString();
                        string nonceStr = context.Session["nonceStr"].ToString();
                        string openid = context.Session["openid"].ToString();

                        //logger.Error("支付步骤timestamp：" + timestamp);
                        //logger.Error("支付步骤nonceStr：" + nonceStr);
                        //logger.Error("支付步骤openid：" + openid);

                        WxPayData data = new WxPayData();
                        data.SetValue("body", billData.ProductName);//商品描述
                        data.SetValue("out_trade_no", billData.BillNumber);//订单号
                        data.SetValue("total_fee", (int)(billData.BillAmount * 100));//总金额,微信是以分为单位
                        data.SetValue("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));//交易起始时间
                        data.SetValue("time_expire", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));//交易结束时间
                        data.SetValue("goods_tag", "");//商品标记
                        data.SetValue("trade_type", "JSAPI");//交易类型
                        data.SetValue("openid", openid); //用户OPENID
                        data.SetValue("product_id", billData.ProductID);//商品ID
                        data.SetValue("spbill_create_ip", ip); //中端IP
                        data.SetValue("sign_type", "MD5"); //中端IP
                        data.SetValue("notify_url", WechatJSAPIConfig.notify_url);
                        data.SetValue("nonce_str", nonceStr);

                        WxPayData result = WxPayApi.UnifiedOrder(data);//调用统一下单接口
                        if (result == null)
                        {
                            message.msg = "0";
                            message.data = "";

                            context.Response.Write(JsonConvert.SerializeObject(message));
                        }

                        string prepay_id = result.GetValue("prepay_id").ToString();//获得统一下单接口返回的二维码链接
                        
                        #endregion

                        //logger.Error("支付步骤订单结构：" + result.ToXml());

                        #region 第三步，生成支付签名                    

                        WxPayData payData = new WxPayData();
                        payData.SetValue("appId", WechatJSAPIConfig.appid);
                        payData.SetValue("timeStamp", timestamp);
                        payData.SetValue("nonceStr", nonceStr);
                        payData.SetValue("package", $"prepay_id={prepay_id}");
                        payData.SetValue("signType", "MD5");

                        string md5sign = payData.MakeSign();

                        //logger.Error("支付步骤签名：" + md5sign);

                        var jsBridge = new
                        {
                            msg = "200",
                            appId = WechatJSAPIConfig.appid,
                            timeStamp = timestamp,
                            nonceStr = nonceStr,
                            mypackage = $"prepay_id={prepay_id}",
                            md5sign = md5sign
                        };

                        string jsApiData = JsonConvert.SerializeObject(jsBridge);

                        //logger.Error("支付步骤json：" + jsApiData);

                        context.Response.Write(jsApiData);

                        #endregion
                    }
                    else
                    {
                        message.msg = "0";
                        message.data = "";
                        context.Response.Write(JsonConvert.SerializeObject(message));
                    }
                }
            }
            catch (Exception ex)
            {
                message.msg = "0";
                message.data = "";
                context.Response.Write(JsonConvert.SerializeObject(message));
            }            
        }
    }
}