using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDD4.DataProcessor.rdd2
{
    public class RDD2Job : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //开启线程处理序列号数据
            Task.Factory.StartNew(() => HandleStatisticsData());
        }

        private void HandleStatisticsData()
        {
            
        }
    }
}
