using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostTutorial
{
    public class HttpGetUtil
    {
        /// <summary>
        /// 发起GET请求
        /// 可重载参数：
        /// 1、Encoding
        /// 2、Content-Type
        /// 3、User-Agent
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string DoGet(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentLength = 0;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.87 Safari/537.36";
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.Headers.Add("Accept-Language: zh-CN,zh;q=0.9");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response != null)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                    string responseData = streamReader.ReadToEnd();
                    return responseData;
                }

                return string.Empty;
            }
            catch
            {
                throw;
            }
        }
    }
}
