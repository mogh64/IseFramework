// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;

namespace ISE.Framework.Common.GenericFactory
{
    class Factory<TFactory> where TFactory : IFactory<TFactory>, new()
    {
        public TProduct Create<TProduct>() where TProduct : IProduct<TFactory>, new()
        {
            return new TFactory().Build<TProduct>();
        }
    }
}
