using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFMasterDetail.ViewModels
{


    public class MDPgaeViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand HomeCommand { get; set; }
        public DelegateCommand P1Command { get; set; }
        public DelegateCommand P2Command { get; set; }

        public MDPgaeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            HomeCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///MDPgae/NaviPage/MainPage");
            });
            P1Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///MDPgae/NaviPage/Page1Page");
            });
            P2Command = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("xf:///MDPgae/NaviPage/Page2Page");
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
