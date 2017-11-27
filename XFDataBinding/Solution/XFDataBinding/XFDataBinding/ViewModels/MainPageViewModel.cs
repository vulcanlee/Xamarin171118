using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFDataBinding.ViewModels
{

    public class MyItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public MySubItem MySubItemData { get; set; }
    }

    public class MySubItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; } = "Hello Xamarin.Forms";
        public MyItem MyItemObject { get; set; }
        public Dictionary<string, int> Dict { get; set; }
        public ObservableCollection<MyItem> MyItemList { get; set; } = new ObservableCollection<MyItem>();
        private readonly INavigationService _navigationService;

        // ?????????????????????????????????????????????????????????????????????????????????????????????????????????
        // 使用建構式與OnNavigatedTo來建立這個 ViewModel 的資料初始化工作，有何不同，請試著比較說明看看
        // ?????????????????????????????????????????????????????????????????????????????????????????????????????????
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // 這些資料初始化的相關工作，您也可以使用 OnNavigatedTo 來做到
            MyItemObject = new MyItem
            {
                FirstName = "Main FirstName",
                MySubItemData = new MySubItem
                {
                    FirstName = "Sub Firstname",
                }
            };

            MyItemList = new ObservableCollection<MyItem>();
            MyItemList.Add(new MyItem() { FirstName = "FN1", LastName = "LN1" });
            MyItemList.Add(new MyItem() { FirstName = "FN2", LastName = "LN2" });
            MyItemList.Add(new MyItem() { FirstName = "FN3", LastName = "LN3" });

            Dict = new Dictionary<string, int>();
            Dict.Add("item1", 100);
            Dict.Add("item2", 120);
            Dict.Add("item3", 140);
            Dict.Add("item4", 160);
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
