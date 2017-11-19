using System;
using Xamarin.Forms;

namespace XFPrismNavigation.Views
{
    public partial class NextPage : ContentPage
    {
        public NextPage()
        {
            InitializeComponent();
        }

        public void OnButton(object s, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
