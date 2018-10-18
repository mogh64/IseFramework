// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.ServiceModel.Description;
using System.Linq;

namespace Router.Contracts
{

    [ServiceContract(Namespace = "http://wcfservice/01")]
    public interface IRouterService
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message ProcessMessage(Message requestMessage);

    }


}
