using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFNavAware.Helpers;

namespace XFNavAware.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoPage1Command { get; set; }
        public DelegateCommand GoDeepCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoPage1Command = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("MyData", "Come from MainPage");
                _navigationService.NavigateAsync("Page1Page", fooPara);
            });
            GoDeepCommand = new DelegateCommand(() =>
            {
                var fooPara1 = new NavigationParameters();
                fooPara1.Add("MyData", "Come from MainPage - Page1");
                var fooPara2 = new NavigationParameters();
                fooPara2.Add("MyData", "Come from MainPage - Page2");
                _navigationService.NavigateAsync($"Page1Page{fooPara1}/Page2Page{fooPara2}");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"MainPage OnNavigatedFrom");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"MainPage OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"MainPage OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"MainPage OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"MainPage OnNavigatedTo");
            if (parameters.CurrentParameters() != "")
            {
                Console.WriteLine($"MainPage OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            Console.WriteLine($"{Environment.NewLine}");
        }

    }

}
