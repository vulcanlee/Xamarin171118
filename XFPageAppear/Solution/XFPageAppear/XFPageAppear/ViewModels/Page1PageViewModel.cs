using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFPageAppear.Helpers;

namespace XFPageAppear.ViewModels
{

    public class Page1PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public readonly IPageDialogService _dialogService;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand ShowLogCommand { get; set; }
        public DelegateCommand ResetLogCommand { get; set; }
        public DelegateCommand AppearingCommand { get; set; }
        public DelegateCommand DisappearingCommand { get; set; }
        public Page1PageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;

            _dialogService = dialogService;
            AppearingCommand = new DelegateCommand(() =>
            {
                MainHelper.WriteLog($"Page1Page Appearing");
            });
            DisappearingCommand = new DelegateCommand(() =>
            {
                MainHelper.WriteLog($"Page1Page Disappearing");
            });
            GoBackCommand = new DelegateCommand(() =>
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

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }
}
