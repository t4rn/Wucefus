using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Wucefus.TestApp.Inspectors
{
    public class CustomHeaderBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public override Type BehaviorType => this.GetType();


        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            CustomHeaderClientInsector inspector = new CustomHeaderClientInsector();
            clientRuntime.ClientMessageInspectors.Add(inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        { }

        public void Validate(ServiceEndpoint endpoint)
        { }

        protected override object CreateBehavior()
        {
            return new CustomHeaderBehavior();
        }
    }
}
