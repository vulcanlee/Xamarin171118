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
using XFListLazy.Models;
using XFListLazy.Repositories;

namespace XFListLazy.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Loading { get; set; }

        public ObservableCollection<MyModel> MyDatas { get; set; } = new ObservableCollection<MyModel>();
        public MyModel SelectedMyData { get; set; }

        private readonly INavigationService _navigationService;
        public MyRepository _myRepository { get; set; }

        public DelegateCommand<MyModel> ItemAppearingCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _myRepository = MyRepository.GetInstance();

            ItemAppearingCommand = new DelegateCommand<MyModel>((x) =>
            {
                var fooLast = MyDatas.Last();
                if (x.ID == fooLast.ID)
                {
                    Reload(fooLast.ID + 1);
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        /// <summary>
        /// 這個函式為事件，回傳值只能夠使用 void
        /// </summary>
        /// <param name="parameters"></param>
        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await Reload(0);
        }

        /// <summary>
        /// 這裡是非同步函式，要回傳 Task，不要使用 void
        /// </summary>
        /// <param name="last"></param>
        public async Task Reload(int last)
        {
            Loading = true;
            var foo = _myRepository.GetNext(last);
            await Task.Delay(2000);
            foreach (var item in foo)
            {
                MyDatas.Add(item);
            }
            Loading = false;
        }

    }
}
