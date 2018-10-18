using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service.Security
{
    public class LoginContext
    {
        private static ServiceLogin serviceLogin = null;
        public static ServiceLogin ServiceLogin {
            get 
            {
                return serviceLogin;
            }
            set
            {
                serviceLogin = value;
            }
        } 
    }
}
