using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCustVM.ViewModels;

namespace XFCustVM.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            //var foo = new NewViewModel();
            //this.BindingContext = foo;
        }

        public void OnChanged(object s, EventArgs e)
        {
            NewViewModel bar = this.BindingContext as NewViewModel;
            bar.Title = "Change Title to New Name";
        }
    }
}