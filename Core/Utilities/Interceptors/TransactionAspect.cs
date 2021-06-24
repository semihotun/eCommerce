using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Utilities.Interceptors
{
    public class TransactionAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
