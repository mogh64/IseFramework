// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
//using AutoMapper;
using ISE.Framework.Common.Service.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;


namespace ISE.Framework.Common.CommonBase
{
    [DataContract]
    [KnownType("GetDerivedTypes")]
    public class BaseDto : IEntity, IDtoResponseEnvelop
    {
        public static List<Type> DerivedTypes = new List<Type>();
        public BaseDto()
        {            
            State = DtoObjectState.Ignore;
            ConsequenceOrder = -1;
        }
        private static IEnumerable<Type> GetDerivedTypes()
        {
            return DerivedTypes;
        }
        public virtual object Id {
            get {
                try
                {
                    object value = this.GetType().GetProperty(PrimaryKeyName).GetValue(this, null);
                    return value;
                }
                catch
                {
                    return null;
                }
            }
        }
        public void SetIdentity(object id)
        {
           this.GetType().GetProperty(PrimaryKeyName).SetValue(this, id, null);
        }
        //[IgnoreMap]
        [DataMember]
        public int ConsequenceOrder { get; set; }
        [DataMember]
        //[IgnoreMap]
        public DtoObjectState State { get; set; }
        [DataMember]
        //[IgnoreMap]
        public string OperationState { get; set; }
        //[IgnoreMap]
        [DataMember]
        public string PrimaryKeyName { get; set; }

        [DataMember]
        //[IgnoreMap]
        private Response responseInstance;

        //[IgnoreMap]
        public Response Response
        {
            get 
            {
                if (responseInstance == null)
                {
                    responseInstance = new Response(Id);
                }
                return responseInstance; 
            }           
        }
        public void SetResponse(Response response)
        {
            responseInstance = response;
        }
        [DataMember]
        public virtual DateTime? InsertDate { get; set; }
        [DataMember]
        public virtual int? UpdatePerId { get; set; }
        [DataMember]
        public virtual DateTime? UpdateDate { get; set; }
        [DataMember]
        public virtual int? InsertPerId { get; set; }
        [DataMember]
        public DateTime DateTimeTimestamp { get; set; }
    }
}
