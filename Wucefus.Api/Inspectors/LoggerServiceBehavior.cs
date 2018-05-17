using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Wucefus.Core.Services.Loggers;

namespace Wucefus.Api.Inspectors
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LoggerServiceBehavior : Attribute, IServiceBehavior
    {
        private readonly IKrisLogger _logger;
        private readonly IDispatchMessageInspector _messageInspector;

        public LoggerServiceBehavior(IKrisLogger logger)
        {
            _logger = logger;
            _messageInspector = new LoggerMessageInspector(_logger);
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            for (int i = 0; i < serviceHostBase.ChannelDispatchers.Count; i++)
            {
                var channelDispatcher = serviceHostBase.ChannelDispatchers[i] as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_messageInspector);
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
