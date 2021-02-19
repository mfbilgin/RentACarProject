using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{

    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}

