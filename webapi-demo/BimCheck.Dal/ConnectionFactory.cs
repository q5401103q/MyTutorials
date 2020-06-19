using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BimCheck.Dal
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:08:00
    /// 描述：
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        private static readonly string connectionName = ConfigurationManager.AppSettings["ConnectionName"];
        /// <summary>
        /// 数据库连接串
        /// </summary>
        private static readonly string connString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            IDbConnection conn = null;
            switch (connectionName)
            {
                case "SQLServer":
                    conn = new SqlConnection(connString);
                    break;
                case "MySQL":
                    conn = new MySqlConnection(connString);
                    break;
                default:
                    conn = new SqlConnection(connString);
                    break;
            }
            conn.Open();
            return conn;
        }
    }
}
