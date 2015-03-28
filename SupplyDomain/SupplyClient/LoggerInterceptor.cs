using System;
using System.Diagnostics;
using Castle.DynamicProxy;

namespace SupplyClient
{
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Method {0}.{1} started invocation at {2}", invocation.TargetType.FullName, invocation.Method.Name, DateTime.Now);
            invocation.Proceed();
            Debug.WriteLine("Method {0}.{1} finished invocation at {2}", invocation.TargetType.FullName, invocation.Method.Name, DateTime.Now);
        }
    }
}