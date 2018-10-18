// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;

namespace ISE.Framework.Common.Service.Wcf
{
    public interface ICommandDispatcher
    {
        TResult ExecuteCommand<TService, TResult>(Func<TService, TResult> command)
            where TResult : IDtoResponseEnvelop
            where TService : class, IServiceContract;
        TResult ExecuteSimpleCommand<TService, TResult>(Func<TService, TResult> command)           
            where TService : class, IServiceContract;
        //TResult ExecuteBatchCommand<TService, TResult>(Func<TService, TResult> command)
        //    where TResult : IList<IDtoResponseEnvelop>
        //    where TService : class, IServiceContract;
        void ExecuteCommand<TService>(Action<TService> command)
            
            where TService : class, IServiceContract;        
    }
}
