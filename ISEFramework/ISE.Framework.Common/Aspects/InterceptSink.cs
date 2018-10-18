
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class InterceptSink : IMessageSink
    {
        private IMessageSink nextSink;
        private Type baseType;
        public InterceptSink(IMessageSink nextSink,Type baseType)
        {
            this.nextSink = nextSink;
            this.baseType = baseType;
        }

        #region IMessageSink Members

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage mcm = (msg as IMethodCallMessage);        
            this.PreProcess(ref mcm);
            IMessage rtnMsg = nextSink.SyncProcessMessage(msg);
            IMethodReturnMessage mrm = (rtnMsg as IMethodReturnMessage);
            this.PostProcess(msg as IMethodCallMessage, ref mrm);
            return mrm;
        }

        public IMessageSink NextSink
        {
            get
            {
                return this.nextSink;
            }
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            IMessageCtrl rtnMsgCtrl = nextSink.AsyncProcessMessage(msg, replySink);
            return rtnMsgCtrl;
        }

        #endregion

        private void PreProcess(ref IMethodCallMessage msg)
        {
            bool canAuthorize = false;
            PreProcessAttribute[] attrs
                = (PreProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(PreProcessAttribute), true);
            for (int i = 0; i < attrs.Length; i++)
                attrs[i].Processor.Process(ref msg);
            if (attrs.Length == 0)
            {
                
                ProcessAttribute[] pattrs
                = (ProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true);
                if (pattrs.Count() > 0)
                {
                    if (msg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true).Count()>0 && !((ProcessAttribute[])msg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true))[0].Authorize)
                    {

                        if (baseType.GetMethod(msg.MethodName).GetCustomAttributes(typeof(ProcessAttribute), true).Count()>0 && ((ProcessAttribute[])baseType.GetMethod(msg.MethodName).GetCustomAttributes(typeof(ProcessAttribute), true))[0].Authorize)
                        {
                            canAuthorize = true;
                        }
                        
                    }
                    else
                    {
                        canAuthorize = true;
                    }
                }
                for (int i = 0; i < pattrs.Length; i++)
                {
                    pattrs[i].PreProcessor.CanAuthorize = canAuthorize;
                    pattrs[i].PreProcessor.Process(ref msg);
                }
                    
            }
        }

        private void PostProcess(IMethodCallMessage callMsg, ref IMethodReturnMessage rtnMsg)
        {
            PostProcessAttribute[] attrs
                = (PostProcessAttribute[])callMsg.MethodBase.GetCustomAttributes(typeof(PostProcessAttribute), true);
            for (int i = 0; i < attrs.Length; i++)
                attrs[i].Processor.Process(callMsg, ref rtnMsg);
            if (attrs.Length == 0)
            {
                ProcessAttribute[] pattrs
                = (ProcessAttribute[])callMsg.MethodBase.GetCustomAttributes(typeof(ProcessAttribute), true);
                for (int i = 0; i < pattrs.Length; i++)
                    pattrs[i].PostProcess(callMsg, ref rtnMsg);
            }
        }

    }
}
