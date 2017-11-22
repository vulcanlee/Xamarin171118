using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFPureMVVM
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _MyEntry;

        public string MyEntry
        {
            get { return _MyEntry; }
            set
            {
                if (_MyEntry != value)
                {
                    _MyEntry = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _MyLabel;

        public string MyLabel
        {
            get { return _MyLabel; }
            set
            {
                if (_MyLabel != value)
                {
                    _MyLabel = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand MyButtonCommand { get; set; }

        public MainPageViewModel()
        {
            MyButtonCommand = new Command(() =>
            {
                MyLabel = MyEntry;
            });
        }

        void OnPropertyChanged(
                [CallerMemberName]string propertyName = "")
        {
            var fooPropertyChanged = PropertyChanged;
            if (fooPropertyChanged != null)
            {
                PropertyChanged(this,
                              new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
