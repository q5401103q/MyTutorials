using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingGenerator
{
    public class TypeConvertor
    {
        /// <summary>
        /// 数据库数据类型, Dot Net数据类型,
        /// </summary>
        public static Dictionary<string, string> dic;

        static TypeConvertor()
        {
            dic = new Dictionary<string, string>();

            dic.Add("char", "string");
            dic.Add("varchar", "string");
            dic.Add("nvarchar", "string");
            dic.Add("ntext", "string");
            dic.Add("int", "int");
            dic.Add("bigint", "Int64");
            dic.Add("decimal", "decimal");
            dic.Add("tinyint", "Byte");
            dic.Add("bit", "bool");
            dic.Add("datetime", "DateTime");
            dic.Add("time", "TimeSpan");            
        }

        public static string ConvertDbTypeToCLRType(string type)
        {
            string result = string.Empty;
            dic.TryGetValue(type, out result);
            return result;
        }
    }
}
