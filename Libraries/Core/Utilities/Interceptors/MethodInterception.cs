using Castle.DynamicProxy;
using Core.Utilities.Results;
using System;
using System.Reflection;
using System.Threading.Tasks;
namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation :  business method
        protected bool IsSuccess { get; set; } = true;
        protected virtual void SetIsSuccess(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                IsSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
