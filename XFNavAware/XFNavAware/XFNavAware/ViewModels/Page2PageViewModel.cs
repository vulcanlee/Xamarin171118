using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using XFNavAware.Helpers;

namespace XFNavAware.ViewModels
{

    public class Page2PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoBackParaCommand { get; set; }
        public DelegateCommand GoHomeCommand { get; set; }
        public DelegateCommand GoHomeParaCommand { get; set; }

        private readonly INavigationService _navigationService;

        public Page2PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackAsync();
            });
            GoBackParaCommand = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("MyReturnData", "Return from Page2");
                _navigationService.GoBackAsync(fooPara);
            });
            GoHomeCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackToRootAsync();
            });
            GoHomeParaCommand = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("MyReturnData", "Return from Page2");
                _navigationService.GoBackToRootAsync(fooPara);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page2 OnNavigatedFrom");
            if(parameters.CurrentParameters()!="")
            {
                Console.WriteLine($"Page2 OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page2 OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"Page2 OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"Page2 OnNavigatedTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"Page2 OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

    }

}
