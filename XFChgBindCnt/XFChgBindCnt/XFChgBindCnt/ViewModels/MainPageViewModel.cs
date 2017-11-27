using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFChgBindCnt.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string YourAnswer { get; set; }
        public string EchoYourAnswer {
            get
            {
                return $"Echo ... {YourAnswer}";
            }
        }

        public MainPageViewModel()
        {
        }

    }
}
