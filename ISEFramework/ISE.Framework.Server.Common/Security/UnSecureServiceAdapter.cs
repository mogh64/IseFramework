// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in september 2014
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ISE.Framework.Server.Common.Security
{
    public class UnSecureServiceAdapter<TService>
        where TService : class, IServiceContract
    {
        public UnSecureServiceAdapter()
        {

        }
        public UnSecureServiceAdapter(IBusinessExceptionManager businessExceptionManager)
        {
            ClientServiceLocator.Instance().ExceptionManager = businessExceptionManager;
        }
        public UnSecureServiceAdapter(IBusinessWarningManager businessWarningManager)
        {
            ClientServiceLocator.Instance().WarningManager = businessWarningManager;
        }
        public UnSecureServiceAdapter(IBusinessExceptionManager businessExceptionManager, IBusinessWarningManager businessWarningManager)
        {
            ClientServiceLocator.Instance().ExceptionManager = businessExceptionManager;
            ClientServiceLocator.Instance().WarningManager = businessWarningManager;
        }
        
        private void SetError()
        {
            WcfCommandContext.CurrentCommandHasError = true;
            WcfCommandContext.ThreadId = Thread.CurrentThread.ManagedThreadId;
        }
        private void SetUnerror()
        {
            WcfCommandContext.CurrentCommandHasError = false;
            WcfCommandContext.ThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        private static TResult DispatchCommand<TResult>(Func<TResult> dispatcherCommand)
            where TResult : IDtoResponseEnvelop
        {
            var asynchResult = dispatcherCommand.BeginInvoke(null, null);
            while (!asynchResult.IsCompleted)
            {
                //Application.DoEvents();
                Thread.CurrentThread.Join(50);
            }
            return dispatcherCommand.EndInvoke(asynchResult);
        }
        private static TResult DispatchSimpleCommand<TResult>(Func<TResult> dispatcherCommand)
        {
            var asynchResult = dispatcherCommand.BeginInvoke(null, null);
            while (!asynchResult.IsCompleted)
            {
                //Application.DoEvents();
                Thread.CurrentThread.Join(50);
            }
            return dispatcherCommand.EndInvoke(asynchResult);
        }
        //private static TResult DispatchBatchCommand<TResult>(Func<TResult> dispatcherCommand)
        //    where TResult : IList<IDtoResponseEnvelop>
        //{
        //    var asynchResult = dispatcherCommand.BeginInvoke(null, null);
        //    while (!asynchResult.IsCompleted)
        //    {
        //        //Application.DoEvents();
        //        Thread.CurrentThread.Join(50);
        //    }
        //    return dispatcherCommand.EndInvoke(asynchResult);
        //}
        private static void DispatchCommand(Action dispatcherCommand)
        {
            var asynchResult = dispatcherCommand.BeginInvoke(null, null);
            while (!asynchResult.IsCompleted)
            {
                //Application.DoEvents();
                Thread.CurrentThread.Join(50);
            }

        }
    }
}

