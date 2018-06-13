using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDD4.DataProcessor.rdd1
{
    public class RDD1Job : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //开启线程处理序列号数据
            Task.Factory.StartNew(() => HandleSerialData());

            //开启线程处理报关单数据
            Task.Factory.StartNew(() => HandleBgdData());
        }

        private void HandleBgdData()
        {
            
        }

        private void HandleSerialData()
        {
            
        }
    }
}
