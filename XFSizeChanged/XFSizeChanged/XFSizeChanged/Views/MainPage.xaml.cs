using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFSizeChanged.ViewModels;

namespace XFSizeChanged.Views
{
	public partial class MainPage : ContentPage
	{
        MainPageViewModel fooMainPageViewModel;
        public MainPage ()
		{
			InitializeComponent ();

            fooMainPageViewModel = this.BindingContext as MainPageViewModel;
            this.SizeChanged += MainPage_SizeChanged;
		}

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {
            if(this.Width < this.Height)
            {
                fooMainPageViewModel.MyFontSize = 20;
            }
            else
            {
                fooMainPageViewModel.MyFontSize = 40;
            }
        }
    }
}