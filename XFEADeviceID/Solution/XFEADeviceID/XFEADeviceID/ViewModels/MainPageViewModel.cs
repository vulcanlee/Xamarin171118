using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFEADeviceID.EventAggregators;

namespace XFEADeviceID.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string DeviceID { get; set; }
        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand GetDeviceIDCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;

            _eventAggregator = eventAggregator;

            GetDeviceIDCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<DevicdIDEvent>().Publish(new DevicdIDPayload());
            });

            _eventAggregator.GetEvent<DevicdIDResponseEvent>().Subscribe(x =>
            {
                DeviceID = x.Message;
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
