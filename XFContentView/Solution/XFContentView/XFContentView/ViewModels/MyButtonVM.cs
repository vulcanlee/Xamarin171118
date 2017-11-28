using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XFContentView.ViewModels
{
    public class MyButtonVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Color BackgroundColor { get; set; }
        public string ButtonLabel { get; set; }
        public Color ButtonLabelColor { get; set; }


        public DelegateCommand MyButtonCommand { get; set; }

        public MyButtonVM()
        {

        }
    }
}
