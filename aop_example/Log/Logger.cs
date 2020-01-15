using log4net;
using log4net.Core;
using System;
using System.Reflection;

namespace aop_example
{
    public static class Logger
    {
        public static ILog Log { get; internal set; } = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }

    public static class LoggerExtensions
    {
        public static void Trace(this ILog log, string message, Exception exception)
        {
            log.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, Level.Trace, message, exception);
        }

        public static void Trace(this ILog log, string message)
        {
            log.Trace(message, null);
        }
    }
}
