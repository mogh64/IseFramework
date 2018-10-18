// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.Message;
using System.Collections.Generic;


namespace ISE.Framework.Common.Service.Wcf.Request
{
    public interface IResponseManager
    {
        void CheckResponse(Response response);
        bool HasWarnings { get; }
        bool HasException { get; }
        string RetrieveWarningsToString();
        IEnumerable<string> Warnings { get; }
        BusinessExceptionDto BusinessExceptionDto { get; }
    }
}