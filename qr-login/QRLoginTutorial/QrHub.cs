using Microsoft.AspNet.SignalR;
using RDD4.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QRLoginTutorial
{
    public class QrHub : Hub
    {
        /// <summary>
        /// 定义redis对象
        /// </summary>
        private DoRedisString redis = new DoRedisString();

        public override Task OnConnected()
        {
            //string guid = Guid.NewGuid().ToString().Replace("-", string.Empty);
            string guid = "1234567890";
            //生成cookie
            HttpCookie cookie = new HttpCookie("qrcodeguid");
            cookie.Value = guid;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            cookie.HttpOnly = true;
            //将cookie写到浏览器
            HttpContext.Current.Response.Cookies.Add(cookie);

            //将连接标志和二维码标志关联起来
            redis.Set(guid, Context.ConnectionId, new TimeSpan(0, 10, 0));
            redis.Set(Context.ConnectionId, guid, new TimeSpan(0, 10, 0));

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}