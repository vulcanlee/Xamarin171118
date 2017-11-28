using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFWebListView.Models;
using XFWebListView.Repositories;

namespace XFWebListView.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ScenicSpot> ScenicSpotList { get; set; } = new ObservableCollection<ScenicSpot>();
        public bool ShowProcessingMask { get; set; } = false;
        private readonly INavigationService _navigationService;

        public DelegateCommand RefreshCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RefreshCommand = new DelegateCommand(async () =>
            {
                await Reload();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Reload();
        }

        public async Task Reload()
        {
            ShowProcessingMask = true;
            try
            {
                #region 只要有存取資源，請記得要將程式碼 try...catch起來
                var fooList = await ScenicSpotRepository.Get();
                ScenicSpotList.Clear();
                foreach (var item in fooList)
                {
                    ScenicSpotList.Add(item);
                }
                #endregion
            }
            finally
            {
                ShowProcessingMask = false;
            }
        }
    }
}
