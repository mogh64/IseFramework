using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service
{
    public class ClientContextBucket
    {
        public static string UserID;
        public static string VerificationCode="test";
        public static string WindowsLogonID;
        public static string KerberosID;
        public static string SiteminderToken;
        public static UserHeaderToken UserHeaderToken=new UserHeaderToken();
        public static void ClearToken()
        {
            UserHeaderToken.Clear();
        }
        public static void SetBucket(ClientContext context)
        {
            if (context != null)
            {
                UserID = context.UserID;
                VerificationCode = context.VerificationCode;
                WindowsLogonID = context.WindowsLogonID;
                KerberosID = context.KerberosID;
                SiteminderToken = context.SiteminderToken;
                UserHeaderToken = context.UserHeaderToken;
            }
           
        }
    }
    public class ClientContext
    {
        public  string UserID;
        public  string VerificationCode = "test";
        public  string WindowsLogonID;
        public  string KerberosID;
        public  string SiteminderToken;
        public  UserHeaderToken UserHeaderToken = new UserHeaderToken();
        public  void ClearToken()
        {
            UserHeaderToken.Clear();
        }
    }
}
