using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogTutorial
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Debug("This is a debug log.");
            logger.Info("This is a info log.");
            logger.Warn("Hey man, I warned you.");
            logger.Error(new ArgumentException("hooooolly shit. An error occured."));
            logger.Fatal(new NullReferenceException("can not do this operation"));

            Console.Read();
        }
    }
}
