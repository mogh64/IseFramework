﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class PreProcessAttribute : Attribute
    {
        private IPreProcessor p;
        public PreProcessAttribute()
        {
            Type preProcessorType = typeof(TracePreProcessor);
            this.p = Activator.CreateInstance(preProcessorType) as IPreProcessor;
            if (this.p == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPreProcessor", preProcessorType.Name, "processorType"));
        }
        public PreProcessAttribute(Type preProcessorType)
        {
            this.p = Activator.CreateInstance(preProcessorType) as IPreProcessor;
            if (this.p == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPreProcessor", preProcessorType.Name, "processorType"));
        }

        public IPreProcessor Processor
        {
            get { return p; }
        }
    }
}
