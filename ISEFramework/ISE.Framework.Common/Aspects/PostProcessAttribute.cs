﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class PostProcessAttribute : Attribute
    {
        private IPostProcessor p;
        public PostProcessAttribute()
        {
            Type postProcessorType = typeof(PostProcessAttribute);
            this.p = Activator.CreateInstance(postProcessorType) as IPostProcessor;
            if (this.p == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPostProcessor", postProcessorType.Name, "processorType"));
        }

        public PostProcessAttribute(Type postProcessorType)
        {
            this.p = Activator.CreateInstance(postProcessorType) as IPostProcessor;
            if (this.p == null)
                throw new ArgumentException(String.Format("The type '{0}' does not implement interface IPostProcessor", postProcessorType.Name, "processorType"));
        }

        public IPostProcessor Processor
        {
            get { return p; }
        }
    }
}
