﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFNavi.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoNextPageCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoNextPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NextPage");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Console.WriteLine($"  ------------  MainPage OnNavigatedFrom");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Console.WriteLine($"  ------------  MainPage OnNavigatingTo");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Console.WriteLine($"  ------------  MainPage OnNavigatedTo");
        }

    }

}
