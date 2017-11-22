using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XFNavAware.Helpers
{
    public class MainHelper
    {
        public static string NavigationLogs = "";
        public static void WriteLog(string log)
        {
            if (NavigationLogs == "")
            {
                NavigationLogs = log;
            }
            else
            {
                NavigationLogs += Environment.NewLine + log;
            }
            Console.WriteLine(log);
        }

        public static async Task ShowLog(IPageDialogService dialogService)
        {
            var fooOutput = $"{Environment.NewLine}{Environment.NewLine}{NavigationLogs}{Environment.NewLine}{Environment.NewLine}";
            await dialogService.DisplayAlertAsync("導航過程日誌", fooOutput, "確定");
        }
    }
}
