using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFMasterDetail.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;


        public DelegateCommand NextCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NextCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("NextPage");
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
