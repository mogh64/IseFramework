
using ISE.Framework.Common.Service.Wcf;
// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in September 2014
using ISE.Framework.Common.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service
{
    public class WcfCurrentContext
    {
        public static UserIdentity CurrentUser
        {
            get
            {
                try
                {
                    if (CurrentContextType == ContextType.ClaimContext)
                    {
                        
                        UserIdentity identity = new UserIdentity()
                        {
                            EmailAddress = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][6].Resource.ToString(),
                            UserId = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][4].Resource.ToString(),
                            SystemName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][3].Resource.ToString(),
                            LastName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][2].Resource.ToString(),
                            FirstName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][1].Resource.ToString(),
                            OrganisationalId = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][7].Resource.ToString(),
                            NationalCode = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][5].Resource.ToString(),
                            UserName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][0].Resource.ToString(),
                            OrganisationName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][8].Resource.ToString(),
                           
                        };
                        return identity;
                    }
                    else
                    {
                        try
                        {
                            if (OperationContext.Current.IncomingMessageProperties.ContainsKey("CurrentContext"))
                            {
                                var serverContext = (ServerContext)OperationContext.Current.IncomingMessageProperties["CurrentContext"];
                                UserIdentity identity = new UserIdentity()
                                {
                                    // EmailAddress = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][6].Resource.ToString(),
                                    UserId = serverContext.UserID,
                                    VerificationCode = serverContext.VerificationCode,
                                    Token = serverContext.UserHeaderToken != null ? serverContext.UserHeaderToken.Token : "",
                                    //SystemName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][3].Resource.ToString(),
                                    //LastName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][2].Resource.ToString(),
                                    //FirstName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][1].Resource.ToString(),
                                    //OrganisationalId = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][7].Resource.ToString(),
                                    //NationalCode = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][5].Resource.ToString(),
                                    //UserName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][0].Resource.ToString(),
                                    //OrganisationName = OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][8].Resource.ToString()
                                };
                                return identity;
                            }
                            
                        }
                        catch
                        {
                            
                        }
                        return new UserIdentity();
                    }
                    
                }
                catch
                {
                    return new UserIdentity();
                }
            }
        }
        private static ContextType currentContextType = ContextType.ServerContext;
        public static ContextType CurrentContextType {
            get
            {
                return currentContextType;
            }
            set
            {
                currentContextType = value;
            }
        }
        public static bool IsAuthenticated
        {
            get
            {
                try
                {
                    if (currentContextType == ContextType.ClaimContext) {
                        if (OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets[0][9].Resource.ToString() == "True")
                            return true;
                    }
                    else
                    {
                        var serverContext = (ServerContext)OperationContext.Current.IncomingMessageProperties["CurrentContext"];
                        if (serverContext != null)
                        {
                            int userId = -1;
                            int.TryParse(serverContext.UserID, out userId);
                            if (userId > 0)
                                return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                return false;
            }
        }
    }
}
