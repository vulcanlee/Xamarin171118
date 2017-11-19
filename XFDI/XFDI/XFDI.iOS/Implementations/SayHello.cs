using System;
using System.Collections.Generic;
using System.Text;
using XFDI.Interfaces;
using XFDI.iOS.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(SayHello))]
namespace XFDI.iOS.Implementations
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
            return " I am iOS";
        }
    }
}
