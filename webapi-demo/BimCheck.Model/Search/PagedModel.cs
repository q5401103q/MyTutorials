using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Search
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:50:44
    /// 描述：
    /// </summary>
    public abstract class PagedModel : BaseModel
    {
        [JsonProperty("pageindex")]
        public int PageIndex { get; set; }

        [JsonProperty("pagesize")]
        public int PageSize { get; set; }
    }
}
