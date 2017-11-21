using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFINPC
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { get; set; }

        #region 一般的用法
        //private string _YourName;

        //public string YourName
        //{
        //    get { return _YourName; }
        //    set
        //    {
        //        if (_YourName != value)
        //        {
        //            _YourName = value;
        //            OnPropertyChanged("YourName");
        //        }

        //    }
        //}

        //private string _YourAnswer;

        //public string YourAnswer
        //{
        //    get { return _YourAnswer; }
        //    set
        //    {
        //        if (_YourName != value)
        //        {
        //            _YourAnswer = value;
        //            OnPropertyChanged("YourAnswer");
        //        }
        //    }
        //}
        #endregion

        #region CallerMemberName 的用法
        private string _YourName;

        public string YourName
        {
            get { return _YourName; }
            set
            {
                if (_YourName != value)
                {
                    _YourName = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _YourAnswer;

        public string YourAnswer
        {
            get { return _YourAnswer; }
            set
            {
                if (_YourName != value)
                {
                    _YourAnswer = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public MainPageViewModel()
        {
            LoginCommand = new Command(() =>
            {
                YourAnswer = "XF: " + YourName;
            });
        }

        //void OnPropertyChanged(string propertyName = "")
        //{
        //    var fooPropertyChanged = PropertyChanged;
        //    if(fooPropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        #region CallerMemberName 的用法
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var fooPropertyChanged = PropertyChanged;
            if (fooPropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
