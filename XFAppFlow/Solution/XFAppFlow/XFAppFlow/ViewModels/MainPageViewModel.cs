using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFAppFlow.Events;

namespace XFAppFlow.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;
        public MainPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.LightPink
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
            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.LightPink
            });
        }

    }
}
