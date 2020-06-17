using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Entity
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:49:38
    /// 描述：
    /// </summary>
    public class Student
    {
        public string SId { get; set; }

        public string Sname { get; set; }

        public DateTime? Sage { get; set; }

        public string Ssex { get; set; }
    }
}
