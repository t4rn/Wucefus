using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Wucefus.Core.Services.Loggers;

namespace Wucefus.Api.Inspectors
{
    public class LoggerEndpointBehavior : IEndpointBehavior
    {
        private readonly IKrisLogger _logger;
        private readonly IDispatchMessageInspector _messageInspector;

        public LoggerEndpointBehavior(IKrisLogger logger)
        {
            _logger = logger;
            _messageInspector = new LoggerMessageInspector(_logger);
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_messageInspector);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
