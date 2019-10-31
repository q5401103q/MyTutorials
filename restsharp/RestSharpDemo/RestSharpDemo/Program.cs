using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Program
    {
        private void TestGet()
        {
            //定义客户端
            var client = new RestClient("http://example.com");

            //定义请求
            var request = new RestRequest("/api/get", Method.GET);
            //请求content-type设置
            request.RequestFormat = DataFormat.Json;
            //请求超时设置，单位毫秒
            request.Timeout = 30 * 1000;
            //请求头部定义
            request.AddHeader("Cache-Control", "no-cache");

            //执行请求
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
        }

        private void TestPost()
        {
            //定义客户端
            var client = new RestClient("http://example.com");

            //定义请求
            var request = new RestRequest("/api/post", Method.POST);
            //请求content-type设置
            request.RequestFormat = DataFormat.Json;
            //请求超时设置，单位毫秒
            request.Timeout = 30 * 1000;
            //请求头部定义
            request.AddHeader("x-access-token", "token");
            //请求参数定义
            request.AddParameter("param1", "string1");
            request.AddParameter("param2", "string2");

            //执行请求
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
        }

        private void TestPut()
        {
            //定义客户端
            var client = new RestClient("http://example.com");
            //定义请求
            var request = new RestRequest("/api/put", Method.PUT);
            //请求content-type设置
            request.RequestFormat = DataFormat.Json;
            //请求超时设置，单位毫秒
            request.Timeout = 30 * 1000;
            //请求头部定义
            request.AddHeader("x-access-token", "token");
            //请求参数定义
            request.AddParameter("param1", "string1");
            request.AddParameter("param2", "string2");
            //请求文件添加
            request.AddFile("file", "C:\\readme.txt");

            //执行请求
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
        }

        private void TestHttpClientPost()
        {
            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 30);

                using (FileStream stream = new FileStream("C:\\readme.txt", FileMode.Open, FileAccess.Read))
                {
                    //获取长度
                    int length = (int)stream.Length;
                    //定义buffer
                    byte[] buffer = new byte[length];
                    //读入缓冲区
                    stream.Read(buffer, 0, length);

                    using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                    {
                        //添加参数
                        content.Add(new StreamContent(new MemoryStream(buffer)), "file", "readme.txt");
                        content.Add(new StringContent("username"), "string1");
                        content.Add(new StringContent("password"), "string2");

                        //执行异步请求
                        var response = client.PostAsync($"http://example.com/api/upload", content);

                        //阻塞线程
                        response.Wait();

                        //获取执行结果
                        Console.WriteLine(response.Result);
                    }
                }
            }
        }
    }
}
