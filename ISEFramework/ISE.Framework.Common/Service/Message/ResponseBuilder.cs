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
    public static class ResponseBuilder
    {
        public static ResponseDto GetResponse(BaseDto baseDto)
        {
            
            ResponseDto response = new ResponseDto(baseDto.Response)
            {                              
                PrimaryKeyName = baseDto.PrimaryKeyName,
                State = baseDto.State,
                ConsequenceOrder = baseDto.ConsequenceOrder
            };
            
            return response;
        }
        public static ResponseDtoContainer GetResponse(List<BaseDto> baseDtos)
        {
            List<ResponseDto> responseLst = new List<ResponseDto>();
            foreach (var baseDto in baseDtos)
            {
                ResponseDto response = new ResponseDto(baseDto.Response)
                {
                    PrimaryKeyName = baseDto.PrimaryKeyName,
                    State = baseDto.State,
                    ConsequenceOrder = baseDto.ConsequenceOrder
                };
                responseLst.Add(response);
            }
            var container = new ResponseDtoContainer(responseLst);
            return container ;
        }
    }
}
