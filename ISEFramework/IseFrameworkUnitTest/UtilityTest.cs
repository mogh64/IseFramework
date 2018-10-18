using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISE.Framework.Common.Logger;
using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service;

namespace IseFrameworkUnitTest
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestDateTimeHelper1()
        {
            int day = ISE.Framework.Utility.Utils.DateTimeHelper.GetPersianDayOfWeek(DateTime.Now);
            Assert.AreEqual(day, 4);
        }
        [TestMethod]
        public void TestStartOfWeek()
        {
            
            DateTime  sday = ISE.Framework.Utility.Utils.DateTimeHelper.GetPersianStartOfWeek(DateTime.Now);
            DateTime eday = ISE.Framework.Utility.Utils.DateTimeHelper.GetPersianEndOfWeek(DateTime.Now);
            Assert.AreEqual(sday.Day, 16);
            Assert.AreEqual(eday.Day, 22);
        }
        //[TestMethod]
        //public void TestGetDateTime()
        //{
        //   string dt= ISE.Framework.Utility.Utils.DateTimeHelper.GetPersianDateString(DateTime.Now);
        //   Assert.IsNotNull(dt);
        //}
        [TestMethod]
        public void TestEncryption()
        {
            string key = "123";
            string original = "asdfHJhhSjk?ssd451";
            var dest = ISE.Framework.Utility.Utils.Encryption.EncryptUrl(original,key);
            var org = ISE.Framework.Utility.Utils.Encryption.DecryptUrl(dest,key);
            Assert.AreEqual(original, org);
        }
        [TestMethod]
        public void TestMD5()
        {
            string password = "mogh64";
            string key = "92000711";
            var md51 = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateHMACMD5(password,key);
                                    
        }
       [TestMethod]
        public void TestLog()
        {
            FileLogger.WriteLog("this is test");
        }
       [TestMethod]
       public void TestContext()
       {
           //ClientContext.UserHeaderToken.Add("ActionId", "-1");
           //ClientContext.UserHeaderToken.Add("UserName", "ali");
           //ClientContext.UserHeaderToken.Add("ActionId", "1");
       }
       [TestMethod]
       public void TestAspect()
       {
           Calc();
       }
      
       private void Calc()
       {
           throw new DivideByZeroException("A Math Error Occured...");
       }
    }
}
