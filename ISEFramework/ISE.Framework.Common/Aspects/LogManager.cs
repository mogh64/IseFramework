using Slf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Aspects
{
    public static class LogManager
    {
        public static ILogger GetLogger()
        {
            ILogger logger = LoggerService.GetLogger();
            return logger;
        }
    }
}
