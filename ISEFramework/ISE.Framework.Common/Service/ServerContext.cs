using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.Framework.Common.Service
{
    public class ServerContext : IExtension<OperationContext>
    {
        public string UserID;
        public string VerificationCode;
        public string WindowsLogonID;
        public string KerberosID;
        public string SiteminderToken;
        public UserHeaderToken UserHeaderToken = new UserHeaderToken();

        // Get the current one from the extensions that are added to OperationContext.
        public static ServerContext Current
        {
            get
            {
                return OperationContext.Current.Extensions.Find<ServerContext>();
            }
        }

        #region IExtension<OperationContext> Members
        public void Attach(OperationContext owner)
        {
        }

        public void Detach(OperationContext owner)
        {
        }
        #endregion
    }
}
