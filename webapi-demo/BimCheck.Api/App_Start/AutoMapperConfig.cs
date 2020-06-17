using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BimCheck.Api
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void InitializeAutoMapper()
        {
            //添加Profile
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(new[] {
                    "BimCheck.Profiles"
                });
            });

            //编译映射
            Mapper.Configuration.CompileMappings();

        }
    }
}