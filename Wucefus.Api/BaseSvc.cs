using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Wucefus.Core.Services.Loggers;

namespace Wucefus.Api
{
    public abstract class BaseSvc
    {
        protected readonly IKrisLogger _log;

        protected BaseSvc(IKrisLogger log)
        {
            _log = log;
        }

        protected string PrepareIp()
        {
            string address = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                MessageProperties properties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                if (properties.Keys.Contains(HttpRequestMessageProperty.Name))
                {
                    HttpRequestMessageProperty endpointLoadBalancer = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (endpointLoadBalancer != null && endpointLoadBalancer.Headers["X-Forwarded-For"] != null)
                        address = endpointLoadBalancer.Headers["X-Forwarded-For"];
                }
                if (string.IsNullOrEmpty(address))
                {
                    address = endpoint.Address;
                }
            }
            catch (Exception ex)
            {
                address = $"Ex: {ex.Message}";
                _log.Error($"[{nameof(PrepareIp)}] Ex: {ex}");
            }

            return address;
        }
    }
}
