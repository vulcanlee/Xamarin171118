using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFPureCSharp
{
    public class MyPage : ContentPage
    {
        Entry MyEntry;
        Label MyLabel;
        Button MyButton;
        public MyPage()
        {
            MyEntry = new Entry();
            MyLabel = new Label();
            MyButton = new Button();
            this.Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    MyEntry,MyLabel,MyButton
                }
            };

            MyEntry.Placeholder = "請輸入你的答案";
            MyButton.Text = "送出";
            MyButton.Clicked += MyButton_Clicked;
        }

        private void MyButton_Clicked(object sender, EventArgs e)
        {
            MyLabel.Text = MyEntry.Text;
        }
    }
}
