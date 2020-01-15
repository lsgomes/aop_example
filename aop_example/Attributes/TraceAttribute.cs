using AspectInjector.Broker;
using System;

namespace aop_example.Attributes
{
    [Aspect(Scope.Global)]
    [Injection(typeof(TraceAttribute))]
    public class TraceAttribute : Attribute
    {
        [Advice(Kind.Before, Targets = Target.Method)]
        public void TraceStart(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name,
            [Argument(Source.Arguments)] object[] args)
        {
            Logger.Log.Trace($"{type.Name}.{name}({string.Join(", ", args)}) started");
        }

        [Advice(Kind.After, Targets = Target.Method)]
        public void TraceFinish(
            [Argument(Source.Type)] Type type,
            [Argument(Source.Name)] string name,
            [Argument(Source.ReturnValue)] object returnValue,
            [Argument(Source.ReturnType)] Type returnType)
        {
            Logger.Log.Trace($"{type.Name}.{name}() finished");
        }
    }
}
