using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFNavAware.Helpers
{
    public static class NavigationParametersExtension
    {
        public static string CurrentParameters(this NavigationParameters navigationParameters)
        {
            var fooResult = "";
            foreach (var item in navigationParameters)
            {
                if (string.IsNullOrEmpty(fooResult))
                {
                    fooResult = $"{item.Key} --> {item.Value}";
                }
                else
                {
                    fooResult += $"\r\n{item.Key} --> {item.Value}";
                }
            }
            return fooResult;
        }
        public static string CurrentInternalParameters(this NavigationParameters navigationParameters)
        {
            var fooResult = "";
            foreach (var item in navigationParameters.InternalParameters)
            {
                if (string.IsNullOrEmpty(fooResult))
                {
                    fooResult = $"{item.Key} --> {item.Value}";
                }
                else
                {
                    fooResult += $"\r\n{item.Key} --> {item.Value}";
                }
            }
            return fooResult;
        }
    }
}
