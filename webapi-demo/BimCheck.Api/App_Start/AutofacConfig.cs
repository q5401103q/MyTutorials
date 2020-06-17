using Autofac;
using Autofac.Integration.WebApi;
using BimCheck.Api.Core;
using BimCheck.Dal;
using BimCheck.IDal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BimCheck.Api
{
    /// <summary>
    /// Autofac配置类
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 初始化autofac
        /// </summary>
        public static void InitializeAutofac()
        {
            //定义Builder
            var builder = new ContainerBuilder();

            //得到你的HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            //注册API控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //注册Autofac过滤器提供商
            builder.RegisterWebApiFilterProvider(config);

            //得到DAL的程序集信息
            var assembly = Assembly.Load(ConfigurationManager.AppSettings["AppDal"]);

            //反射获取类型信息
            var appDataRepository = assembly.GetType(ConfigurationManager.AppSettings["AppDataRepository"], true, true);
            var appSession = assembly.GetType(ConfigurationManager.AppSettings["AppSession"], true, true);

            //注册类型
            builder.RegisterType(appDataRepository).As<IDataRepository>();
            builder.RegisterType(appSession).As<ISession>();

            //注册服务类
            builder.RegisterAssemblyTypes(Assembly.Load(ConfigurationManager.AppSettings["AppBll"]))
                   .Where(x => x.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            //注册日志模块
            builder.RegisterModule(new LoggingModule());

            //将依赖关系解析器设置为Autofac
            var container = builder.Build();

            //设置WebApi依赖注入
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}