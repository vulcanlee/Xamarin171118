using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFEADeviceID.EventAggregators
{
    public class DevicdIDResponseEvent : PubSubEvent<DevicdIDResponsePayload>
    {

    }

    public class DevicdIDResponsePayload
    {
        public string Message { get; set; }
    }
}
