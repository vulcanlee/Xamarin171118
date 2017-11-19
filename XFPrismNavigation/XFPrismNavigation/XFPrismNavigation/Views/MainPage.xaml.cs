using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFPrismNavigation.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        public void OnButton(object s, EventArgs e)
        {
            Navigation.PushAsync(new NextPage());
        }

    }
}