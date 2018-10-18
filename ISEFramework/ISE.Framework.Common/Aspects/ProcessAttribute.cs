using ISE.Framework.Common.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public class ProcessAttribute : Attribute
    {
        private IPreProcessor p1;
        private IPostProcessor p2;
        private IPostProcessor p3;
        public bool Authorize = false;
        public ProcessAttribute(bool authorize=false)
        {
            this.Authorize = authorize;
            Type preProcessorType = typeof(TracePreProcessor);
            this.p1 = Activator.CreateInstance(preProcessorType) as IPreProcessor;
            if (this.p1 == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPreProcessor", preProcessorType.Name, "processorType"));

            Type postProcessorType = typeof(TracePostProcessor);
            this.p2 = Activator.CreateInstance(postProcessorType) as IPostProcessor;
            if (this.p2 == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPostProcessor", postProcessorType.Name, "postProcessorType"));

            Type exceptionProcessorType = typeof(TraceExceptionProcessor);
            this.p3 = Activator.CreateInstance(exceptionProcessorType) as IPostProcessor;
            if (this.p3 == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPostProcessor", exceptionProcessorType.Name, "exceptionProcessorType"));

            if (Dependency.DependencyContainer.ServiceAuthorization != null )
            {
                this.p1.AddAuthorization(Dependency.DependencyContainer.ServiceAuthorization);
            }
        }

        public ProcessAttribute(Type preProcessorType, Type postProcessorType, bool authorize = false)
        {
            this.Authorize = authorize;
            this.p1 = Activator.CreateInstance(preProcessorType) as IPreProcessor;
            if (this.p1 == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPreProcessor", preProcessorType.Name, "processorType"));
            this.p2 = Activator.CreateInstance(postProcessorType) as IPostProcessor;
            if (this.p2 == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPreProcessor", postProcessorType.Name, "processorType"));
            if (Dependency.DependencyContainer.ServiceAuthorization != null )
            {
                this.p1.AddAuthorization(Dependency.DependencyContainer.ServiceAuthorization);
            }
        }
       
        public void PostProcess(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            if (retMsg.Exception != null)
            {
                this.ExceptionProcessor.Process(callMsg, ref retMsg);
            }
            else
            {
                this.PostProcessor.Process(callMsg, ref retMsg);
            }
        }
        public IPreProcessor PreProcessor
        {
            get { return p1; }
        }
        public IPostProcessor PostProcessor
        {
            get { return p2; }
        }
        public IPostProcessor ExceptionProcessor
        {
            get { return p3; }
        }
    }
}
