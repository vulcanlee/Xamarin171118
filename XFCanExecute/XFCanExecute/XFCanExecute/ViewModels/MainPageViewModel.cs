using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFCanExecute.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyEntry { get; set; } = "1112223";
        public string MyLabel { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        private readonly INavigationService _navigationService;

        void OnMyEntryChanged()
        {
            LoginCommand.RaiseCanExecuteChanged();
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(
                () =>
                {
                    MyLabel = MyEntry;
                }
                ,
                () =>
                {
                    if (MyEntry.Length > 6)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                );
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
