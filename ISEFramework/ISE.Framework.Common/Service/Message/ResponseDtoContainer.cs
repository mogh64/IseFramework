// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    public class ResponseDtoContainer : DtoContainer
    {
        public ResponseDtoContainer()
        {
            ResponseDtoList = new List<ResponseDto>();
        }
        public ResponseDtoContainer(List<ResponseDto> responseList)
        {
            ResponseDtoList = new List<ResponseDto>();
            if (responseList != null)
            {
                foreach (var response in responseList)
                {
                    Add(response);
                }
            }            
        }
        public void Add(ResponseDto responseDto)
        {           
            this.Response.AddBusinessException(responseDto.Response.BusinessException);
            ResponseDtoList.Add(responseDto);
        }
        public List<ResponseDto> ResponseDtoList { get; set; }
        public bool ContainKey(object key)
        {
            var searchObj = ResponseDtoList.FirstOrDefault(it => it.Key == key);
            if(searchObj!=null){
                return true;
            }
            return false;
        }
    }
}
