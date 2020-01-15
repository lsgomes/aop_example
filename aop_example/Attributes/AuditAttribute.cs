using aop_example.Model;
using aop_example.Services;
using AspectInjector.Broker;
using System;
using System.Linq;
using Action = aop_example.Model.Action;

namespace aop_example.Attributes
{
    [Aspect(Scope.Global)]
    [Injection(typeof(AuditAttribute))]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuditAttribute : Attribute
    {
        private readonly Action Action = Action.UNKNOWN;
        public AuditAttribute() { }
        public AuditAttribute(Action action)
        {
            Action = action;
        }

        [Advice(Kind.Before, Targets = Target.Method)]
        public void AuditAction(
            [Argument(Source.Arguments)] object[] args,
            [Argument(Source.Triggers)] Attribute[] triggers)
        {
            string username = args[0] as string;

            User user = UserService.Instance.GetUser(username);

            string actions = string.Empty;

            foreach (var trigger in triggers.OfType<AuditAttribute>())
            {
                actions += trigger.Action;
            }

            Logger.Log.Info($"User named {user.Name} with role {user.Role} performed {actions} at {DateTime.Now}.");
        }
    }
}
