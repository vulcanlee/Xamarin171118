using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XFAppFlow.Events;

namespace XFAppFlow.ViewModels
{

    public class ThemePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand GoHomeCommand { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public ThemePageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            GoHomeCommand = new DelegateCommand(() =>
            {
                _navigationService.GoBackToRootAsync();
            });

            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.Orange
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
            await System.Threading.Tasks.Task.Delay(90);
            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.Orange
            });
        }

    }
}
