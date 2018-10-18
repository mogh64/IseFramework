// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    [DataContract]
    public class ResponseDto : BaseDto
    {
       
        public ResponseDto(Response response)
        {
            Key = response.EntityId;
            PrimaryKeyName = "Key";
            this.SetResponse(response);           
        }
        [DataMember]
        public object Key
        {
            get;
            set;
        }
        public string Message
        {
            get
            {
                return this.Response.BusinessException.Message;
            }
        }
        public ResponseDto()
        {
           
        }
    }
}
