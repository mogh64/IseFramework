using ISE.Framework.Client.Common.Base;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Client.Win.Base
{
    public class ViewBase<T>:IViewBase<T> where T:BaseDto
    {
        public ViewBase(IPresenterBase<T> presenter)
        {
            Presenter = presenter;
        }
        IPresenterBase<T> Presenter;
        public ClientContext ClientContext
        {
            get {
                if (Presenter != null)
                    return Presenter.ClientContext;
                else return null;
            } 
            set 
            {
                if (Presenter != null)
                {
                    Presenter.ClientContext = value;
                }
            } 
        }
    }
}
