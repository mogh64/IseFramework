// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf.Request
{
    /// <remarks>
    /// version 0.71 Context Re-Factor
    /// </remarks>  
    public class Container
    {
        public static IGlobalContext GlobalContext
        {
            get
            {
                return ISE.Framework.Common.Service.Wcf.Request.GlobalContext.Instance();
            }
        }
        
        public static IRequestContext RequestContext { get; set; }
    }
}
