// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.CommonBase
{
    [DataContract]
    public class DtoContainer : IDtoResponseEnvelop
    {
        public DtoContainer()
        {
            ResponseInstance = new Response();
        }
        [DataMember]
       
        private  Response ResponseInstance;

       
        public Response Response
        {
            get { return ResponseInstance; }
        }
        [DataMember]
        public DateTime DateTimeTimestamp { get; set; }
    }
}
