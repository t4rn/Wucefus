using System.ServiceModel;
using Wucefus.Core.Dto;

namespace Wucefus.Api
{
    [ServiceContract]
    public interface IConsents
    {
        [OperationContract]
        string Ping(int value);

        [OperationContract]
        GetConsentsResultDto GetConsentsAll();
    }
}
