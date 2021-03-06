﻿using Autofac;
using Autofac.Integration.WebApi;
using BimCheck.Api.Core;
using BimCheck.Dal;
using BimCheck.IDal;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(BimCheck.Api.Startup))]
namespace BimCheck.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //初始化Autofac
            AutofacConfig.InitializeAutofac();

            //初始化AutoMapper
            AutoMapperConfig.InitializeAutoMapper();

            //初始化Dapper
            DapperConfig.InitializeDapper();

            //初始化OAuth2
            OAuth2Config.InitializeOAuth2(app);

            //获取配置
            var config = GlobalConfiguration.Configuration;

            //拒绝XML这种愚蠢的类型
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //注册WEBAPI及路由
            WebApiConfig.Register(config);

            //owin使用配置
            app.UseWebApi(config);

            //允许跨域访问
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}