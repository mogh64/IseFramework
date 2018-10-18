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

namespace ISE.Framework.Common.PersistantPackage
{
    [DataContract]
    public class PersistanceBox
    {
        private int index = 0;
        public PersistanceBox()
        { 
            PersistanceList= new List<BaseDto>();
        }     
        [DataMember]
        public List<BaseDto> PersistanceList { get; private set; }
        public void Add(BaseDto dto)
        {           
            if(dto.ConsequenceOrder<0)
            {
                dto.ConsequenceOrder = index++;
            }
            PersistanceList.Add(dto);
        }
        public void Add(List<BaseDto> dtoList)
        {
            foreach (var dto in dtoList)
            {
                if (dto.ConsequenceOrder < 0)
                {
                    dto.ConsequenceOrder = index++;
                }
                PersistanceList.Add(dto);
            }          
        }       
    }
}
