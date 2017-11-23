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

    public class NaviPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Color NaviBarColor { get; set; } = Color.Yellow;

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public NaviPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Subscribe(x =>
            {
                NaviBarColor = x.BarColor;
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
