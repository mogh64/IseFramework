﻿// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    public interface IBusinessWarningManager
    {
        void HandleBusinessWarning(IEnumerable<BusinessWarning> warnings);
    }
}
