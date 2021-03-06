﻿using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFPageEvent.Events;

namespace XFPageEvent.ViewModels
{

    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyEntry { get; set; }
        private readonly INavigationService _navigationService;

        public DelegateCommand PublishCommand { get; set; }

        private readonly IEventAggregator _eventAggregator;
        public NextPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            PublishCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<EchoEvent>()
                .Publish(new EchoPayload()
                {
                     Message= MyEntry,
                });
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
