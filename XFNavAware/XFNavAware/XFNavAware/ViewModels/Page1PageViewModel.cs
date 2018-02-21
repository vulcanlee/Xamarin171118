using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
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
        public DelegateCommand GoBackMainPageCommand { get; set; }
        public DelegateCommand ResetLogCommand { get; set; }
        public DelegateCommand ShowLogCommand { get; set; }

        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        public Page1PageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;

            _dialogService = dialogService;
            GoPage2Command = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("MyData", "Come from Page1");
                _navigationService.NavigateAsync("Page2Page", fooPara);
            });
            GoBackMainPageCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackAsync();
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
            MainHelper.WriteLog($"Page1 OnNavigatedFrom");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page1 OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"Page1 OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page1 OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"Page1 OnNavigatedTo");
            MainHelper.WriteLog($"");
            MainHelper.WriteLog($"Page1 InternalParameters Parameter:{Environment.NewLine}{parameters.CurrentInternalParameters()}");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page1 OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

    }
}
