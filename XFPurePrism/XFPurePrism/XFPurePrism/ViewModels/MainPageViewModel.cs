using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFPurePrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        #region MyEntry
        private string _MyEntry;
        /// <summary>
        /// MyEntry
        /// </summary>
        public string MyEntry
        {
            get { return this._MyEntry; }
            set { this.SetProperty(ref this._MyEntry, value); }
        }
        #endregion


        #region MyLabel
        private string _MyLabel;
        /// <summary>
        /// MyLabel
        /// </summary>
        public string MyLabel
        {
            get { return this._MyLabel; }
            set { this.SetProperty(ref this._MyLabel, value); }
        }
        #endregion

        public DelegateCommand MyButtonCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";

            MyButtonCommand = new DelegateCommand(() =>
            {
                MyLabel = MyEntry;
            });
        }
    }
}
