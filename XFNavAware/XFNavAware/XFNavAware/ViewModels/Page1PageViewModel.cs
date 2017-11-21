using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFNavAware.Helpers;

namespace XFNavAware.ViewModels
{

    public class Page1PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoPage2Command { get; set; }

        private readonly INavigationService _navigationService;

        public Page1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoPage2Command = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("MyData", "Come from Page1");
                _navigationService.NavigateAsync("Page2Page", fooPara);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page1 OnNavigatedFrom");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"Page1 OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page1 OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"Page1 OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page1 OnNavigatedTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"Page1 OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

    }

}
