using System.ServiceModel;
using System.Threading;

namespace Wucefus.Api
{
    public class Duplexus : IDuplexus
    {
        IDuplexusCallback Callback => OperationContext.Current.GetCallbackChannel<IDuplexusCallback>();

        public void DoWork(int x, int y)
        {
            Thread.Sleep(3000);
            string result = $"You've sent x: {x} and y: {y}";

            Callback.Notify(result);
        }
    }
}
