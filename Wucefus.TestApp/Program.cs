using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wucefus.TestApp.SoapConsents;

namespace Wucefus.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConsents();

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

        private static string Serialize<T>(T result)
        {
            return JsonConvert.SerializeObject(result,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
