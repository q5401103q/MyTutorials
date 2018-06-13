using Autofac;
using AutoFac.Tutorial.model;
using System;

namespace AutoFac.Tutorial
{
    class Program
    {
        private static IContainer _container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AesEncryptor>().As<IEncrypt>();
            builder.RegisterType<AesDecryptor>().As<IDecrypt>();
            builder.RegisterType<TodayWriter>().As<IWriter>();
            _container = builder.Build();

            Test();
            Console.ReadLine();
        }

        public static void Test()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IWriter>();
                writer.Write();
            }
        }
    }
}
