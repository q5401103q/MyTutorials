using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using QRLoginTutorial.Common;
using RDD4.Redis;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRLoginTutorial.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 定义redis对象
        /// </summary>
        private DoRedisString redis = new DoRedisString();

        /// <summary>
        /// 主视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GenQrcode()
        {
            string qrcodeId = "98987845412222225555444444888878";

            //生成二维码的失效时间
            var timestamp = DateTime.Now.AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss");

            //定义info内容
            JObject info = new JObject();
            info.Add("qrcodeId", qrcodeId);
            //info.Add("timestamp", timestamp);
            string encryptedInfo = _3DESHelper.EncodeCBCstr(info.ToString(), "key");

            //定义json内容
            JObject json = new JObject();
            json.Add("action", "login");
            json.Add("info", encryptedInfo);

            //定义二维码生成器
            var qrGenerator = new QRCodeGenerator();
            //创建二维码数据
            var qrCodeData = qrGenerator.CreateQrCode(JsonConvert.SerializeObject(json), QRCodeGenerator.ECCLevel.Q);
            //生成二维码对象
            var qrcode = new QRCode(qrCodeData);

            //生成Bitmap
            using (Bitmap qrCodeImage = qrcode.GetGraphic(120, Color.Black, Color.White, null, 15, 6, false))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //写入流文件
                    qrCodeImage.Save(ms, ImageFormat.Jpeg);
                    //返回图片
                    return File(ms.ToArray(), "image/jpeg");
                }
            }
        }

        /// <summary>
        /// 手机扫码调用
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AppLogin(AppData jsonString)
        {
            string clientId = redis.Get("1234567890");

            //Login by uid
            var _instance = GlobalHost.ConnectionManager.GetHubContext("QrHub").Clients;
            _instance.Client(clientId).broadcastMessage("200", "success");

            JObject result = new JObject();
            result.Add("flag", true);

            return Json(result);
        }


        [HttpPost]
        public ActionResult AppRedirect()
        {
            JObject result = new JObject();
            result.Add("flag", true);
            result.Add("comname", "大连龙图");
            result.Add("qylx", "11");

            string clientId = redis.Get("1234567890");
            //把拿到的信息，返回给前台
            var _instance = GlobalHost.ConnectionManager.GetHubContext("QrHub").Clients;
            _instance.Client(clientId).broadcastMessage("200", result.ToString());

            return Content(result.ToString());
        }
	}
}