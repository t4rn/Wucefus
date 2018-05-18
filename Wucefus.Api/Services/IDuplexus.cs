using System.ServiceModel;

namespace Wucefus.Api
{
    [ServiceContract(CallbackContract = (typeof(IDuplexusCallback)))]
    public interface IDuplexus
    {
        [OperationContract(IsOneWay = true)]
        void DoWork(int x, int y);
    }

    public interface IDuplexusCallback
    {
        [OperationContract(IsOneWay = true)]
        void Notify(string msg);
    }
}
