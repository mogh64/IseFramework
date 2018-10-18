using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Service
{
    public class ConfigManager
    {
        public static string GetConfigFileFullPath()
        {
            return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        }
    }
}
