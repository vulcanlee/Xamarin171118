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

    public class SystemPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public SystemPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.Red
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
            await System.Threading.Tasks.Task.Delay(30);
            _eventAggregator.GetEvent<ChangeNaviBarColorEvent>().Publish(new ChangeNaviBarColorPayload()
            {
                BarColor = Color.Red
            });
        }

    }
}
