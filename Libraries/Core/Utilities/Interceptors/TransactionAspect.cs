using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using System;
namespace Core.Utilities.Interceptors
{
    //public class TransactionAspect : MethodInterception
    //{
    //    private readonly Type _dbContextType;
    //    public TransactionAspect(Type dbContextType)
    //    {
    //        _dbContextType = dbContextType;
    //    }
    //    public override void Intercept(IInvocation invocation)
    //    {
    //        var db = ServiceTool.ServiceProvider.GetService(_dbContextType) as DbContext;
    //        using (var transactionScope = db.Database.BeginTransaction())
    //        {
    //            try
    //            {
    //                invocation.Proceed();
    //                transactionScope.Commit();
    //            }
    //            catch (Exception)
    //            {
    //                transactionScope.Rollback();
    //            }
    //        }
    //    }
    //}
}
