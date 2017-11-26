﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFListView.Models;
using XFListView.Repositories;

namespace XFListView.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int RefreshIndex { get; set; } = 0;
        private readonly INavigationService _navigationService;
        public bool RefreshingStatus { get; set; }
        public MyTaskItem MyTaskItemSelected { get; set; }
        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();

        public DelegateCommand MyTaskItemSelectedCommand { get; set; }

        public DelegateCommand MyTaskRefreshCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MyTaskRefreshCommand = new DelegateCommand(() =>
            {
                RefreshIndex++;
                MyTaskItemList.Clear();
                MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
                var fooTasks = fooMyTaskRepository.GetMyTask();
                foreach (var item in fooTasks)
                {
                    MyTaskItemList.Add(new MyTaskItem
                    {
                        MyTaskName = $"{RefreshIndex} {item.MyTaskName}",
                        MyTaskDate = item.MyTaskDate,
                        MyTaskStatus = item.MyTaskStatus,
                    });
                }
                RefreshingStatus = false;
            });

            MyTaskItemSelectedCommand = new DelegateCommand(async () =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("Record", MyTaskItemSelected.Clone());
                await _navigationService.NavigateAsync("TaskDetailPage", fooPara);

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

            if (parameters.ContainsKey("Action"))
            {
                string action = parameters["Action"] as string;
                var fooObj = parameters["ActionRec"] as MyTaskItem;

                switch (action)
                {
                    case "D":
                        var bar = MyTaskItemList.FirstOrDefault(x => x.MyTaskName == fooObj.MyTaskName);
                        if(bar != null)
                        {
                            MyTaskItemList.Remove(fooObj);
                        }
                        break;
                    case "S":
                        var barS = MyTaskItemList.FirstOrDefault(x => x.MyTaskName == fooObj.MyTaskName);
                        if (barS != null)
                        {
                            barS.MyTaskName = fooObj.MyTaskName;
                            barS.MyTaskStatus = fooObj.MyTaskStatus;
                            barS.MyTaskDate = fooObj.MyTaskDate;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (MyTaskItemList.Count == 0)
            {
                MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
                var fooTasks = fooMyTaskRepository.GetMyTask();
                foreach (var item in fooTasks)
                {
                    MyTaskItemList.Add(new MyTaskItem
                    {
                        MyTaskName = item.MyTaskName,
                        MyTaskDate = item.MyTaskDate,
                        MyTaskStatus = item.MyTaskStatus,
                    });
                }
            }
        }

    }
}
