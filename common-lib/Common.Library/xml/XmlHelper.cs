﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Library.xml
{
    public static class XmlHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">对象引用</param>
        /// <param name="omitXmlDeclaration">是否忽略xml头部，默认是true</param>
        /// <returns></returns>
        public static string Serialize<T>(this T obj, bool omitXmlDeclaration = false)
        {
            var sb = new StringBuilder();
            using (var xw = XmlWriter.Create(sb, new XmlWriterSettings()
            {
                OmitXmlDeclaration = omitXmlDeclaration,
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true
            }))
            {
                var xs = new XmlSerializer(obj.GetType());
                xs.Serialize(xw, obj);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="xml">被反序列化的字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                {
                    return (T)xs.Deserialize(sr);
                }
            }
        }
    }
}
