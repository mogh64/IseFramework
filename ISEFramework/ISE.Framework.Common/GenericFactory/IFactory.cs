// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;

namespace ISE.Framework.Common.GenericFactory
{
    public interface IFactory<TFactory>
    {
        TProduct Build<TProduct>() where TProduct : IProduct<TFactory>, new();
    }
}
