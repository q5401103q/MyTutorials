using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostTutorial
{
    public class HttpPostUtil
    {
        /// <summary>
        /// 发起POST请求
        /// 可重载参数：
        /// 1、Encoding
        /// 2、Content-Type
        /// 3、User-Agent
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DoPost(string url, string data)
        {
            try
            {
                byte[] postData = Encoding.UTF8.GetBytes(data);

                //构造Post请求
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.62 Safari/537.36";
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.Headers.Add("Accept-Language: zh-CN,zh;q=0.9");

                Stream newStream = request.GetRequestStream();//创建一个Stream,赋值是写入HttpWebRequest对象提供的一个stream里面
                newStream.Write(postData, 0, postData.Length);
                newStream.Close();

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
