using System.Web.Http;
using WebActivatorEx;
using BimCheck.Api;
using Swashbuckle.Application;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BimCheck.Api
{
    /// <summary>
    /// Swagger������
    /// </summary>
    public class SwaggerConfig
    {
        public static void Register()
        {
            //��ȡ��ǰ�ĳ�����Ϣ
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            //����Swagger
            GlobalConfiguration.Configuration
            .EnableSwagger(swagger =>
            {
                swagger.SingleApiVersion("v1", "�ӿ�˵���ĵ�");
                swagger.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin\\BimCheck.Api.xml"));
            })
            .EnableSwaggerUi();
        }
    }
}
