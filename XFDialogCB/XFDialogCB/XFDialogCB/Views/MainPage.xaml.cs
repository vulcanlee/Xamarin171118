using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDialogCB.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

        public async void OnOption(object s, EventArgs e)
        {
            var fooResult = await DisplayActionSheet("Information", "取消", null,
               "Option1", "Option2", "Option3", "Option4");
            Answer.Text = $"你的回答是 {fooResult}";
        }

        public async void OnMessage(object s, EventArgs e)
        {
            var fooAnswer = await this.DisplayAlert("警告", "此功能需要連上網路，你確定要繼續嗎?", "是", "否");
            Answer.Text = $"你選擇的是 {fooAnswer}";
        }

    }
}