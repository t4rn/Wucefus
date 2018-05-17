using System;
using System.ServiceModel.Configuration;

namespace Wucefus.Api.Inspectors
{
    public class LoggerBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(LoggerEndpointBehavior);

        protected override object CreateBehavior()
        {
            //return new LoggerEndpointBehavior();
            return null;
        }
    }
}
