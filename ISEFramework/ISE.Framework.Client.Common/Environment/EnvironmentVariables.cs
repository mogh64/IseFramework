
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Client.Common.Environment
{
    public enum EnvironmentType{
        Win,
        Web,
        Android,
        Console,
        iOS
    }
    public class EnvironmentVariables
    {
        private static EnvironmentType Environment = EnvironmentType.Win;
        private static Dictionary<EnvironmentType, IBussinessExceptionViewer> exceptionViewers = new Dictionary<EnvironmentType, IBussinessExceptionViewer>();
        public static void RegisterViewer(IBussinessExceptionViewer viewer,EnvironmentType envType)
        {
            exceptionViewers.Add(envType, viewer);
        }
        public static IBussinessExceptionViewer GetCurrentViewer
        {
            get
            {
                return exceptionViewers[Environment];
            }
        }
        public static EnvironmentType CurrentEnvironment
        {
            get
            {
                return Environment;
            }
            set
            {
                Environment = value;
            }
        }
    }
}
