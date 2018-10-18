// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ISE.Framework.Common.Service
{
    public class ServiceAdapter<TService>
        where TService: class, IServiceContract
    {       
        public ServiceAdapter()
        {

        }
        public ClientContext ClientContext { get; set; }
        public ServiceAdapter(IBusinessExceptionManager businessExceptionManager)
        {
            ClientServiceLocator.Instance().ExceptionManager = businessExceptionManager;
        }
        public ServiceAdapter(IBusinessWarningManager businessWarningManager)
        {
            ClientServiceLocator.Instance().WarningManager = businessWarningManager;
        }
        public ServiceAdapter(IBusinessExceptionManager businessExceptionManager,IBusinessWarningManager businessWarningManager)
        {
            ClientServiceLocator.Instance().ExceptionManager = businessExceptionManager;
            ClientServiceLocator.Instance().WarningManager = businessWarningManager;
        }
        
        public TResult Execute<TResult>(Func<TService, TResult> command)
            where TResult : IDtoResponseEnvelop
        {
            try
            {                                
               // Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                if (ClientContext!=null)
                   ClientContextBucket.SetBucket(ClientContext);
                var dispatcher = ClientServiceLocator.Instance().CommandDispatcher;                
                var result = DispatchCommand(() => dispatcher.ExecuteCommand(command));
                //if (result.Response.HasWarning)
                //{
                //    ClientServiceLocator.Instance()
                //        .WarningManager
                //        .HandleBusinessWarning(result.Response.BusinessWarnings);

                //}
                if (result!=null && result.Response!=null && result.Response.HasException)
                {
                    SetError();
                   // Mouse.OverrideCursor = null;
                    ClientServiceLocator.Instance()
                        .ExceptionManager
                        .HandleBusinessException(result.Response.BusinessException);
                }
                else
                {
                    SetUnerror();
                }
                return result;
            }
            finally
            {
               // Mouse.OverrideCursor = null;
            }
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
        public TResult ExecuteSimple<TResult>(Func<TService, TResult> command)          
        {
            try
            {
                // Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                if (ClientContext != null)
                   ClientContextBucket.SetBucket(ClientContext);
                var dispatcher = ClientServiceLocator.Instance().CommandDispatcher;               
                var result = DispatchSimpleCommand(() => dispatcher.ExecuteSimpleCommand(command));
                //if (result.Response.HasWarning)
                //{
                //    ClientServiceLocator.Instance()
                //        .WarningManager
                //        .HandleBusinessWarning(result.Response.BusinessWarnings);

                //}
                
                return result;
            }
            finally
            {
                // Mouse.OverrideCursor = null;
            }
        }
        //public TResult ExecuteBatch<TResult>(Func<TService, TResult> command)
        //   where TResult : IList<IDtoResponseEnvelop>
        //{
        //    try
        //    {
        //        // Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        //        var dispatcher = ClientServiceLocator.Instance().CommandDispatcher;
        //        var result = DispatchBatchCommand(() => dispatcher.ExecuteBatchCommand(command));
        //        //if (result.Response.HasWarning)
        //        //{
        //        //    ClientServiceLocator.Instance()
        //        //        .WarningManager
        //        //        .HandleBusinessWarning(result.Response.BusinessWarnings);

        //        //}
        //        if (result != null && result.Count > 0)
        //        {
        //            // Mouse.OverrideCursor = null;
        //            var businessExceptionList =   result.Select(it => it.Response.BusinessException).ToList();
        //            ClientServiceLocator.Instance()
        //                .ExceptionManager
        //                .HandleBusinessException(businessExceptionList);
        //        }
        //        return result;
        //    }
        //    finally
        //    {
        //        // Mouse.OverrideCursor = null;
        //    }
        //}
        public void  Execute(Action<TService> command)
            
        {
            try
            {
                // Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                if (ClientContext != null)
                    ClientContextBucket.SetBucket(ClientContext);
                var dispatcher = ClientServiceLocator.Instance().CommandDispatcher;
                 DispatchCommand(() => dispatcher.ExecuteCommand(command));
                //if (result.Response.HasWarning)
                //{
                //    ClientServiceLocator.Instance()
                //        .WarningManager
                //        .HandleBusinessWarning(result.Response.BusinessWarnings);

                //}
                //if (result.Response.HasException)
                //{
                //    // Mouse.OverrideCursor = null;
                //    ClientServiceLocator.Instance()
                //        .ExceptionManager
                //        .HandleBusinessException(result.Response.BusinessException);
                //}
               
            }
            finally
            {
                // Mouse.OverrideCursor = null;
            }
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

