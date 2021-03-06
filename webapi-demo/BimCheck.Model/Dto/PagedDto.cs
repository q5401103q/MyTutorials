﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Dto
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:46:49
    /// 描述：
    /// </summary>
    public class PagedDto
    {
        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
