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
    public class Page2PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoBackParaCommand { get; set; }
        public DelegateCommand GoHomeCommand { get; set; }
        public DelegateCommand GoHomeParaCommand { get; set; }
        public DelegateCommand ResetLogCommand { get; set; }
        public DelegateCommand ShowLogCommand { get; set; }

        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        public Page2PageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;

            _dialogService = dialogService;
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
            MainHelper.WriteLog($"Page2 OnNavigatedFrom");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page2 OnNavigatedFrom Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"Page2 OnNavigatingTo");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page2 OnNavigatingTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            MainHelper.WriteLog($"Page2 OnNavigatedTo");
            MainHelper.WriteLog($"");
            MainHelper.WriteLog($"Page2 InternalParameters Parameter:{Environment.NewLine}{parameters.CurrentInternalParameters()}");
            if (parameters.CurrentParameters() != "")
            {
                MainHelper.WriteLog($"Page2 OnNavigatedTo Parameter:\r\n{parameters.CurrentParameters()}");
            }
            MainHelper.WriteLog($"");
        }

    }
}
