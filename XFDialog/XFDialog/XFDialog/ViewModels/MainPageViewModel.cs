using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFDialog.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Answer { get; set; }
        private readonly INavigationService _navigationService;

        public DelegateCommand OptionCommand { get; set; }
        public DelegateCommand MessageCommand { get; set; }

        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            OptionCommand = new DelegateCommand(async () =>
            {
               var fooResult =  await _dialogService.DisplayActionSheetAsync("Information", "取消", null,
                    "Option1", "Option2", "Option3", "Option4");
                Answer = $"你的回答是 {fooResult}";
            });
            MessageCommand = new DelegateCommand(async () =>
            {
                var fooAnswer = await _dialogService.DisplayAlertAsync("警告", "此功能需要連上網路，你確定要繼續嗎?", "是", "否");
                Answer = $"你選擇的是 {fooAnswer}";
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
