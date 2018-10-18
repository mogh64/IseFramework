using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Client.Common.Base
{
    public interface IPresenterBase<T> where T :BaseDto
    {
        ClientContext ClientContext { get; set; }
    }
}
