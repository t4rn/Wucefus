using Newtonsoft.Json;
using System;
using System.ServiceModel;
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
            using (ConsentsClient client = new ConsentsClient())
            {
                // not necessary
                client.ClientCredentials.UserName.UserName = "user";
                client.ClientCredentials.UserName.Password = "p@ssw0rd";
                var result = client.GetConsentsAll();

                string jsonResult = Serialize(result);

                Console.WriteLine($"result:\n{jsonResult}");
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
            Console.WriteLine($"DoSomDuplexWork Done for x = {x} and y = {y}. Waiting for result...");
        }

        private static string Serialize<T>(T result)
        {
            return JsonConvert.SerializeObject(result,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
