﻿using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using Wucefus.Core.Extensions;

namespace Wucefus.Api.Inspectors
{
    public class LoggerMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            request = LogMessage(request.CreateBufferedCopy(int.MaxValue));

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            reply = LogMessage(reply.CreateBufferedCopy(int.MaxValue));
        }

        private Message LogMessage(MessageBuffer buffer)
        {
            Message msg = buffer.CreateMessage();
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xw = XmlWriter.Create(sb))
            {
                msg.WriteMessage(xw);
                xw.Close();
            }

            string logMsg = $"Message content:\n {sb.ToString().CleanWhiteSpaces()}";
            Debug.WriteLine(logMsg);
            //_log.Debug(logMsg);

            foreach (var header in msg.Headers)
            {
                string headerMsg = $"Header: {header}";
                Debug.WriteLine(headerMsg);
                //_log.Debug(headerMsg);
            }

            return buffer.CreateMessage();
        }
    }
}
