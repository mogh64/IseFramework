// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.PersistantPackage;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;


namespace ISE.Framework.Common.Service.ServiceBase
{
     [ServiceContract(Namespace = "http://www.iseikco.com/",SessionMode=SessionMode.Required)]
    public interface IServiceBase : IServiceContract
    {
        [OperationContract]
        [Process]
        DtoContainer GetAll();
        [OperationContract]
        [Process]
        DtoContainer GetAllByCondition(string predicate);
        [OperationContract]
        [Process]
        DtoContainer PagedResultGetAll(int page,int pageCount);
        [OperationContract]
        [Process]
        DtoContainer PagedResultGetAllByCondition(string predicate, int page, int pageCount);
        [OperationContract]
        [Process]
        BaseDto GetSingle(long id);
        [OperationContract]
        [Process]
        DtoContainer InsertBatch(PersistanceBox dtoList);
        [OperationContract]
        [Process]
        BaseDto Insert(BaseDto dto);
        [OperationContract]
        [Process]
        ResponseDtoContainer DeleteBatch(PersistanceBox dtoList);
        [OperationContract]
        [Process]
        ResponseDto Delete(BaseDto dto);
        [OperationContract]
        [Process]
        ResponseDtoContainer UpdateBatch(PersistanceBox dtoList);
        [OperationContract]
        [Process]
        ResponseDto Update(BaseDto dto);
        [OperationContract]
        [Process]
        void UpdatePackage(UpdatePackageBox updatePackage);
    }
}
