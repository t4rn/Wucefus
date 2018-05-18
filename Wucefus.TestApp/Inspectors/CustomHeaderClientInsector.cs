using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Wucefus.TestApp.Inspectors
{
    public class CustomHeaderClientInsector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            AddHeader(request, "UserName", "ProWcfTester");
            AddHeader(request, "Password", "GR42cHYTRDzO");

            return null;
        }

        private void AddHeader(Message request, string headerName, string headerValue)
        {
            MessageHeader messageHeader = MessageHeader.CreateHeader(headerName, "http://wucefus.com", headerValue);
            request.Headers.Add(messageHeader);
        }

        /// <summary>
        /// Doesn't work?
        /// </summary>
        public object BeforeSendRequestAddProperties(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;

            string headerName = "Hash";
            string headerValue = "fuy052Ury6Gj";

            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;

                if (string.IsNullOrEmpty(httpRequestMessage.Headers[headerName]))
                {
                    httpRequestMessage.Headers[headerName] = headerValue;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization, headerValue);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }

            return null;
        }
    }
}
