using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFAppFlow.Events
{

    public class ChangeNaviBarColorEvent : PubSubEvent<ChangeNaviBarColorPayload>
    {

    }

    public class ChangeNaviBarColorPayload
    {
        public Color BarColor { get; set; }
    }
}
