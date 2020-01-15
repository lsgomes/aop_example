using AspectInjector.Broker;
using System;
using System.Diagnostics;

namespace aop_example.Attributes
{
    [Aspect(Scope.Global)]
    [Injection(typeof(MeasurePerformanceAttribute))]
    public class MeasurePerformanceAttribute : Attribute
    {
        [Advice(Kind.Around, Targets = Target.Method)]
        public object PerformanceStart(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name,
            [Argument(Source.Target)] Func<object[], object> methodDelegate,
            [Argument(Source.Arguments)] object[] args)
        {
            Logger.Log.Info($"{type.Name}.{name}() started at {DateTime.Now}.");

            var stopwatch = Stopwatch.StartNew();

            var result = methodDelegate(args);

            stopwatch.Stop();

            Logger.Log.Info($"{type.Name}.{name}() finished at {DateTime.Now}. Time elapsed: {stopwatch.Elapsed}");

            return result;
        }
    }
}
