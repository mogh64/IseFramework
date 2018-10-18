// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.CommonBase
{
    public class IdentitySetter
    {
        List<BaseDto> dtoList = new List<BaseDto>();       
        public IdentitySetter(List<BaseDto> resultDtoList)
        {
            this.dtoList = resultDtoList;
        }
        public void SetIdentity(BaseDto desinationDto)
        {
            if(dtoList!=null && dtoList.Count>0)
            {
                var item = dtoList.FirstOrDefault(it => it.ConsequenceOrder == desinationDto.ConsequenceOrder);
                if (item != null && item.Id != null)
                {
                    desinationDto.SetIdentity(item.Id);
                }
                
            }
        }
        
        public void SetIdentity(List<BaseDto> desinationDtoList)
        {
            if (dtoList != null && dtoList.Count > 0)
            {
                foreach (var desinationDto in desinationDtoList)
                {
                    var item = dtoList.FirstOrDefault(it => it.ConsequenceOrder == desinationDto.ConsequenceOrder);
                    if (item != null && item.Id != null)
                    {
                        desinationDto.SetIdentity(item.Id);
                    }                    
                }                
            }
        }
    }
}
