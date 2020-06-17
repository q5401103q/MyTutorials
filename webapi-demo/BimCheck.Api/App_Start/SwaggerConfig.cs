using System.Web.Http;
using WebActivatorEx;
using BimCheck.Api;
using Swashbuckle.Application;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BimCheck.Api
{
    /// <summary>
    /// Swagger配置类
    /// </summary>
    public class SwaggerConfig
    {
        public static void Register()
        {
            //获取当前的程序集信息
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            //配置Swagger
            GlobalConfiguration.Configuration
            .EnableSwagger(swagger =>
            {
                swagger.SingleApiVersion("v1", "接口说明文档");
                swagger.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin\\BimCheck.Api.xml"));
            })
            .EnableSwaggerUi();
        }
    }
}
