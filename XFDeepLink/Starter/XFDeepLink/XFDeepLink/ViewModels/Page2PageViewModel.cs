using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFDeepLink.ViewModels
{

    public class Page2PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string PagePara { get; set; }
        public DelegateCommand GoNextCommand { get; set; }
        private readonly INavigationService _navigationService;

        public Page2PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoNextCommand = new DelegateCommand(async () =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("Data", "Come from Page2");
                await _navigationService.NavigateAsync("Page3Page", fooPara);
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
            if (parameters.ContainsKey("Data"))
            {
                PagePara = parameters["Data"] as string;
            }
        }

    }
}
