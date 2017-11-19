using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFPrismMVVM.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string MyEntry { get; set; }
        public string MyLabel { get; set; }
        public DelegateCommand MyButtonCommand { get; set; }
        public MainPageViewModel()
        {
            Title = "Main Page";

            MyButtonCommand = new DelegateCommand(() =>
            {
                MyLabel = MyEntry;
            });
        }

    }
}
