using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BimCheck.Api
{
    /// <summary>
    /// Dapper配置类
    /// </summary>
    public class DapperConfig
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void InitializeDapper()
        {
            //获取配置的连接方式
            string connectionName = ConfigurationManager.AppSettings["ConnectionName"];
            switch (connectionName)
            {
                case "SQLServer":
                    //使用SQL Server方言
                    DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqlServerDialect();
                    break;
                case "MySQL":
                    //使用MySQL方言
                    DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
                    break;
                default:
                    break;
            }
        }
    }
}