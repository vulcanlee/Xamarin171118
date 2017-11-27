using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFChgBindCnt.ViewModels;

namespace XFChgBindCnt.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            var fooVM = new MainPageViewModel();
            this.BindingContext = fooVM;
		}
	}
}