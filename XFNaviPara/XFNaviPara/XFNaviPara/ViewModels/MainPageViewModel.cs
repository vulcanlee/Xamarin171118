using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFNaviPara.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyName { get; set; }
        public string MyAccount { get; set; }
        private readonly INavigationService _navigationService;

        public DelegateCommand GoNextCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoNextCommand = new DelegateCommand(() =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add(nameof(MyName), MyName);
                fooPara.Add("MyAccount", MyAccount);
                var qs = fooPara.ToString();
                _navigationService.NavigateAsync("NextPage", fooPara);
                //_navigationService.NavigateAsync("NextPage"+fooPara.ToString());
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
