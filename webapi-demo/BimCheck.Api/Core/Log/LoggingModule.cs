using Autofac.Core;
using Autofac.Core.Registration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BimCheck.Api.Core
{
    public class LoggingModule : Autofac.Module
    {
        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            //找到Public并且类型是Looger，且包含setter的属性
            var properties = instanceType
              .GetProperties(BindingFlags.Public | BindingFlags.Instance)
              .Where(p => p.PropertyType == typeof(Logger) && p.CanWrite && p.GetIndexParameters().Length == 0);

            //注入并实例化对象
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType.FullName), null);
            }
        }

        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
            new[]
            {
                new ResolvedParameter(
                    (p, i) => p.ParameterType == typeof(Logger),
                    (p, i) => LogManager.GetLogger(p.Member.DeclaringType.FullName)
                ),
            });
        }

        protected override void AttachToComponentRegistration(IComponentRegistryBuilder componentRegistryBuilder, IComponentRegistration registration)
        {
            //处理构造函数的参数
            registration.Preparing += OnComponentPreparing;

            //处理属性
            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}