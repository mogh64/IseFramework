// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.Framework.Common.Service.Message
{
    public class Response
    {
        #region Constructors

        public Response() : this(0) {
           
        }

        public Response(object entityId)
        {
            
            entityIdInstance = entityId;
        }

        #endregion
        #region Private Serializable Members

        [DataMember]
        public BusinessExceptionDto BusinessExceptionInstance;

        //[DataMember]
        //public IList<BusinessWarning> BusinessWarningList = new List<BusinessWarning>();

        [DataMember]
        private  object entityIdInstance;

        #endregion
        #region Public Methods

        public void AddBusinessException(BusinessException exception)
        {
            if (BusinessExceptionInstance == null)
            {
                BusinessExceptionInstance = new BusinessExceptionDto(exception.ExceptionType, exception.Message, exception.StackTrace);
            }
            
        }
        public void AddBusinessException(string exceptionMessage, Framework.Common.Service.Message.BusinessExceptionEnum exceptionType)
        {
            if (BusinessExceptionInstance == null)
            {                
                BusinessExceptionInstance = new BusinessExceptionDto(exceptionType, exceptionMessage, "");

            }

        }
        public void AddBusinessException(BusinessExceptionDto exception)
        {
            if (exception != null && BusinessExceptionInstance == null)
            {
                BusinessExceptionInstance = exception;
            }
            
        }
        //public void AddBusinessWarnings(IEnumerable<BusinessWarning> warnings)
        //{
        //    warnings.ToList().ForEach(w => BusinessWarningList.Add(w));
        //}

        #endregion
        #region Public Getters

        //public bool HasWarning
        //{
        //    get { return BusinessWarningList.Count > 0; }
        //}

        //public IEnumerable<BusinessWarning> BusinessWarnings
        //{
        //    get { return new List<BusinessWarning>(BusinessWarningList); }
        //}

        public object EntityId
        {
            get { return entityIdInstance; }
        }

        public bool HasException
        {
            get { return BusinessExceptionInstance!=null; }
        }

        public BusinessExceptionDto BusinessException
        {
            get { return BusinessExceptionInstance; }
        }

        #endregion
    }
}
