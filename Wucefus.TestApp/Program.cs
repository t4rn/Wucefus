using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Wucefus.TestApp.SoapConsents;
using Wucefus.TestApp.SoapDuplexus;

namespace Wucefus.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConsents();

            DoSomeDuplexWork();

            Console.Read();
        }

        private static void GetConsents()
        {
            string headerName = "Hash";
            string headerValue = "fuy052Ury6Gj";

            using (ConsentsClient client = new ConsentsClient())
            {
                using (new OperationContextScope(client.InnerChannel))
                {
                    MessageHeader messageHeader = MessageHeader.CreateHeader(headerName, "http://wucefus.com", headerValue);
                    OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);

                    var result = client.GetConsentsAll();

                    string jsonResult = Serialize(result);

                    Console.WriteLine($"{nameof(GetConsents)} result:\n{jsonResult}");
                }
            }
        }

        private static void DoSomeDuplexWork()
        {
            int x = 4;
            int y = 7;
            CallbackHandler callbacker = new CallbackHandler();
            InstanceContext instanceContext = new InstanceContext(callbacker);

            DuplexusClient client = new DuplexusClient(instanceContext);
            client.DoWork(x, y);
            Console.WriteLine($"{nameof(DoSomeDuplexWork)} Done for x = {x} and y = {y}. Waiting for result...");
        }

        private static string Serialize<T>(T result)
        {
            return JsonConvert.SerializeObject(result,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
