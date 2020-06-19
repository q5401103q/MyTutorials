using BimCheck.Api.Core;
using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BimCheck.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //配置OAuth的Filter
            config.Filters.Add(new SimpleAuthorizationFilter());

            //配置全局异常Filter
            config.Filters.Add(new GlobalExceptionFilter());

            //配置FluentValidation校验Filter
            config.Filters.Add(new ValidateModelStateFilter());
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
