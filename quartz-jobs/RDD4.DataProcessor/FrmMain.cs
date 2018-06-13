using Quartz;
using Quartz.Impl;
using RDD4.DataProcessor.rdd1;
using RDD4.DataProcessor.rdd2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDD4.DataProcessor
{
    public partial class FrmMain : Form
    {
        private ISchedulerFactory factory = null;
        private IScheduler scheduler_rdd1 = null;
        private IScheduler scheduler_rdd2 = null;

        public FrmMain()
        {
            InitializeComponent();
            InitializeQuartz();
        }

        private void InitializeQuartz()
        {
            //定义调度工厂
            factory = new StdSchedulerFactory();

            //定义调度器
            scheduler_rdd1 = factory.GetScheduler();
            scheduler_rdd2 = factory.GetScheduler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定义任务
            IJobDetail job = JobBuilder.Create<RDD1Job>()
                                             .UsingJobData("1", 0)
                                             .UsingJobData("1", 0)
                                             .UsingJobData("1", 0)
                                             .Build();

            //定义触发器, 每天凌晨0点运行
            ITrigger trigger = TriggerBuilder.Create()
                                             .StartAt(DateTime.Now.AddSeconds(10))
                                             .Build();

            //使用调度器管理触发器和任务
            scheduler_rdd1.ScheduleJob(job, trigger);

            //启动调度器
            scheduler_rdd1.Start();

            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //定义任务
            IJobDetail job = JobBuilder.Create<RDD2Job>()
                                             .UsingJobData("1", 0)
                                             .UsingJobData("1", 0)
                                             .UsingJobData("1", 0)
                                             .Build();

            //定义触发器, 每天凌晨0点运行
            ITrigger trigger = TriggerBuilder.Create()
                                             .StartAt(DateTime.Now.AddSeconds(10))
                                             .Build();

            //使用调度器管理触发器和任务
            scheduler_rdd2.ScheduleJob(job, trigger);

            //启动调度器
            scheduler_rdd2.Start();

            button2.Enabled = false;
        }

        /// <summary>
        /// 重写窗体关闭事件，强制杀掉工作进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
