using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFAppFlow.Events;

namespace XFAppFlow.ViewModels
{

    public class MDPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<string> NavigateCommand { get; set; }

        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;

        public MDPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            NavigateCommand = new DelegateCommand<string>(async x =>
            {
                switch (x)
                {
                    case "首頁":
                        await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage");
                        break;
                    case "個人資訊":
                        await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/PersonalPage");
                        break;
                    case "主題佈景":
                        await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/SystemPage/PreferencePage/ThemePage");
                        break;
                    case "登出":
                        var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "您確定要登出嗎?", "確定", "取消");
                        if (fooAnswer == true)
                        {
                            await _navigationService.NavigateAsync("xf:///LoginPage");
                        }
                        break;
                    default:
                        break;
                }
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
