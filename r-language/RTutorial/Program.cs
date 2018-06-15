using RDotNet;
using RDotNet.NativeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestRVersion();
                HelloWorld();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }
        }

        private static void TestRVersion()
        {
            REngine.SetEnvironmentVariables(@"D:\r\R-3.2.5\bin\i386", @"D:\r\R-3.2.5\bin\i386"); // <-- May be omitted; next line would call it.
            REngine engine = REngine.GetInstance();

            string[] version = engine.Evaluate("R.version.string").AsCharacter().ToArray();
            string versionStr = string.Join("", version);
            Console.WriteLine(versionStr);
            engine.Dispose();
        }

        private static void HelloWorld()
        {
            REngine.SetEnvironmentVariables(@"D:\r\R-3.2.5\bin\i386", @"D:\r\R-3.2.5\bin\i386"); // <-- May be omitted; the next line would call it.
            REngine engine = REngine.GetInstance();
            // A somewhat contrived but customary Hello World:
            CharacterVector charVec = engine.CreateCharacterVector(new[] { "Hello, R world!, .NET speaking" });
            engine.SetSymbol("greetings", charVec);
            engine.Evaluate("str(greetings)"); // print out in the console
            string[] a = engine.Evaluate("'Hi there .NET, from the R engine'").AsCharacter().ToArray();
            Console.WriteLine("R answered: '{0}'", a[0]);
            Console.WriteLine("Press any key to exit the program");
            engine.Dispose();
        }

        

        /// <summary>
        /// 测试不成功，slam要求R Version >= 3.4.0
        /// </summary>
        private static void TestImage()
        {
            try
            {
                REngine.SetEnvironmentVariables(@"D:\r\R-3.2.5\bin\i386", @"D:\r\R-3.2.5\bin\i386");
                REngine engine = REngine.GetInstance();
                engine.Initialize();

                var x = engine.Evaluate("jpeg('test.jpg',quality=90)");
                engine.Evaluate("library(wordcloud)");
                engine.Evaluate("colors=c('red','blue','green','yellow','purple')");
                engine.Evaluate(" data(SOTU);wordcloud(SOTU,min.freq=10,colors=colors);dev.off()");
                x = engine.Evaluate("r=readBin('test.jpg','raw',3000*3000);unlink('test.jpg');r");

                byte[] bs = x.AsRaw().ToArray();
                Image img = Image.FromStream(new MemoryStream(bs));
                img.Save("e:/my.jpg", ImageFormat.Jpeg);

                engine.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void TestCustomFucntion()
        {
            REngine.SetEnvironmentVariables(@"D:\r\R-3.2.5\bin\i386", @"D:\r\R-3.2.5\bin\i386");
            REngine engine = REngine.GetInstance();
            engine.Initialize();

            int num1 = 10;
            int num2 = 20;
            engine.Evaluate("source('D:/r/R-3.4.3/myR/calculate.R')");
            int result = (int)engine.Evaluate(string.Format("myAdd({0},{1})", num1, num2)).AsNumeric().FirstOrDefault();

            Console.WriteLine(result);

            engine.Dispose();
        }
    }
}