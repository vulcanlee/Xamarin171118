using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFPrismDBinding.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _YourName;

        public string YourName
        {
            get { return _YourName; }
            set { SetProperty(ref _YourName, value); }
        }


        #region YourAnswer
        private string _YourAnswer;
        /// <summary>
        /// YourAnswer
        /// </summary>
        public string YourAnswer
        {
            get { return this._YourAnswer; }
            set { this.SetProperty(ref this._YourAnswer, value); }
        }
        #endregion


        public DelegateCommand LoginCommand { get; set; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            LoginCommand = new DelegateCommand(() =>
            {
                YourAnswer = "XF : " + YourName;
            });
        }
    }
}
