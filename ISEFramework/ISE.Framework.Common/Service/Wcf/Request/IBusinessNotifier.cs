// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ISE.Framework.Common.Service.Wcf.Request
{
    /// <remarks>
    /// version 0.5 Chapter V: Service Locator
    /// </remarks>
    public interface IBusinessNotifier
    {
        void AddWarning(BusinessWarningEnum warningType, string message);
        bool HasWarnings { get; }
        IEnumerable<BusinessWarning> RetrieveWarnings();
    }
}
