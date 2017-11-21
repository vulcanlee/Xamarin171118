using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFDeepLink.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoNextCommand { get; set; }
        public DelegateCommand DeepNaviCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoNextCommand = new DelegateCommand(async () =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("Data", "Come from MainPage");
                await _navigationService.NavigateAsync("Page1Page", fooPara);
            });

            DeepNaviCommand = new DelegateCommand(async () =>
            {
                var fooPara1 = new NavigationParameters();
                fooPara1.Add("Data", "!! Come from MainPage");
                var fooPara2 = new NavigationParameters();
                fooPara2.Add("Data", "!! Come from Page1");
                var fooPara3 = new NavigationParameters();
                fooPara3.Add("Data", "!! Come from Page2");

                //var deepLink = $"Page1Page/Page2Page/Page3Page";
                var deepLink = $"Page1Page{fooPara1.ToString()}/Page2Page{fooPara2.ToString()}/Page3Page{fooPara3.ToString()}";

                await _navigationService.NavigateAsync(deepLink);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }

}
