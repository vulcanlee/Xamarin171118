using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
        public DelegateCommand ResetLogCommand { get; set; }
        public DelegateCommand ShowLogCommand { get; set; }

        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

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
            ResetLogCommand = new DelegateCommand(() =>
            {
                MainHelper.NavigationLogs = "";
            });
            ShowLogCommand = new DelegateCommand(async () =>
            {
                await MainHelper.ShowLog(_dialogService);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"MainPage OnNavigatedFrom");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"MainPage OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"MainPage OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"MainPage OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"MainPage OnNavigatedTo");
            MainHelper.WriteLog($"");
            MainHelper.WriteLog($"MainPage InternalParameters Parameter:{Environment.NewLine}{parameters.CurrentInternalParameters()}");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"MainPage OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

    }
}
