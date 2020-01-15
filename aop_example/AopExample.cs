using aop_example.Attributes;
using Action = aop_example.Model.Action;
using System;
using System.IO;
using log4net;
using log4net.Config;
using System.Reflection;
using System.Threading;

namespace aop_example
{
    class AopExample
    {
        public static void Main(string[] args)
        {
            ConfigureLogging();

            Console.WriteLine("Hello World!");

            Login("John Doe");
            ChangePassword("Administrator");

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

        }

        [MeasurePerformance]
        public static void SlowMethod()
        {
            Thread.Sleep(3000);
        }

        [Audit(Action.LOGIN)]
        public static void Login(string username)
        {

        }

        [Audit(Action.CHANGE_PASSWORD)]
        public static void ChangePassword(string username)
        {

        }

        public static void ConfigureLogging()
        {
            GlobalContext.Properties["LogFileName"] = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "aop_example.log");
            XmlConfigurator.ConfigureAndWatch(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "log4net.config")));
        }
    }
}
