// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf.Request
{
    public interface IRequestContext
    {
        IBusinessNotifier Notifier { get; }
        IResponseManager ResponseManager { get; }
    }
}
