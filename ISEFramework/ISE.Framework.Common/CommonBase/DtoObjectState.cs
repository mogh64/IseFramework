// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Linq;
using System.Runtime.Serialization;


namespace ISE.Framework.Common.CommonBase
{
    [DataContract]
    public enum DtoObjectState
    {
        [EnumMember]
        Ignore = -1,
        [EnumMember]
        Temporary=0,
        [EnumMember]
        Deleted=1,
        [EnumMember]
        Updated=2,
        [EnumMember]
        Persisted=3,
        [EnumMember]
        Inserted = 4
    }
}
