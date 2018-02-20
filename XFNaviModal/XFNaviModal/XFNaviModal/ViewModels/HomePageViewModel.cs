using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFNaviModal.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoPage1Command { get; set; }
        public DelegateCommand GoPage1ModalCommand { get; set; }
        public DelegateCommand GoPage1NaviCommand { get; set; }
        public DelegateCommand GoPage2NaviCommand { get; set; }
        public DelegateCommand GoPage2ModalCommand { get; set; }
        public DelegateCommand GoPage2Command { get; set; }
        public DelegateCommand GoPage1NaviDrawerCommand { get; set; }
        public DelegateCommand GoPage2NaviDrawerCommand { get; set; }
        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoPage1Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page");
            });
            GoPage2Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page/Page2Page");
            });
            GoPage1ModalCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page", null, true);
            });
            GoPage2ModalCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page/Page2Page", null, true);
            });
            GoPage1NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page1Page", null, true);
            });
            GoPage2NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page1Page/Page2Page", null, true);
            });
            GoPage1NaviDrawerCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("MD2Page/NavigationPage/Page1Page", null, true);
            });
            GoPage2NaviDrawerCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("MD2Page/NavigationPage/Page1Page/Page2Page", null, true);
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
