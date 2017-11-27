using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFUserCtrlEntry.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyEntryVM Name { get; set; }
        public MyEntryVM ID { get; set; }
        public MyEntryVM Email { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // 進行三個文字輸入盒要綁定的 ViewModel 的物件初始化
            Name = new MyEntryVM();
            Name.更新文字輸入盒的浮水印文字設定("Name");
            ID = new MyEntryVM();
            ID.更新文字輸入盒的浮水印文字設定("ID");
            Email = new MyEntryVM();
            Email.更新文字輸入盒的浮水印文字設定("Email");
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
