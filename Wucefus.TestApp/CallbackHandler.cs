using System;
using Wucefus.TestApp.SoapDuplexus;

namespace Wucefus.TestApp
{
    public class CallbackHandler : IDuplexusCallback
    {
        public void Notify(string msg)
        {
            Console.WriteLine($"Message from WCF: {msg}");
        }
    }
}
