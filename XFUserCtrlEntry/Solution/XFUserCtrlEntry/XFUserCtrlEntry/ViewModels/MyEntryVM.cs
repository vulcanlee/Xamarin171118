using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XFUserCtrlEntry.ViewModels
{
    public class MyEntryVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 這個文字輸入盒的類型，指定不同的類型，文字輸入盒會有不同的能力表現出來
        /// </summary>
        public string MyPlaceholderType { get; set; }
        /// <summary>
        /// 文字輸入盒沒有任何文字輸入的時候，要顯示甚麼浮水印文字
        /// </summary>
        public string MyPlaceholder { get; set; }
        /// <summary>
        /// 輸入文字的格式驗證是否正確
        /// </summary>
        public bool ValueCorrect { get; set; }
        /// <summary>
        /// 要顯示格式是否正確的文字，要更漂亮，可以使用圖片或者 Font Awesome取代
        /// </summary>
        public string ValueCorrectSymbol { get; set; }
        /// <summary>
        /// 儲存使用者輸入文字的地方
        /// </summary>
        public string MyEntryText { get; set; }
        /// <summary>
        /// 使用者輸入文字格式是否正確的背景顏色定義
        /// </summary>
        public Color ValueCorrectBoxBackground { get; set; }

        #region 當輸入的內容有異動的時候，所要做的商業邏輯檢查程序
        public void OnMyEntryTextChanged()
        {
            if (MyPlaceholderType == "Name")
            {
                if (MyEntryText.Length < 6)
                {
                    ValueCorrect = false;
                }
                else
                {
                    ValueCorrect = true;
                }
                更新文字格式驗證符號與背景顏色();
            }
            else if (MyPlaceholderType == "ID")
            {
                ValueCorrect = 驗證身份證字號格式(MyEntryText);
                更新文字格式驗證符號與背景顏色();
            }
            else if (MyPlaceholderType == "Email")
            {
                ValueCorrect = 驗證電子郵件格式(MyEntryText);
                更新文字格式驗證符號與背景顏色();
            }
        }
        #endregion

        public MyEntryVM()
        {
            // 進行建構式的屬性初始化
            ValueCorrect = false;
            ValueCorrectSymbol = "X";
            MyPlaceholderType = "";
            MyEntryText = "";
            ValueCorrectBoxBackground = Color.Red;
        }

        public void 更新文字格式驗證符號與背景顏色()
        {
            if (ValueCorrect == false)
            {
                ValueCorrectSymbol = "X";
                ValueCorrectBoxBackground = Color.Red;
            }
            else
            {
                ValueCorrectSymbol = "V";
                ValueCorrectBoxBackground = Color.Green;
            }
        }
        public void 更新文字輸入盒的浮水印文字設定(string pMyPlaceholderType)
        {
            MyPlaceholderType = pMyPlaceholderType;
            if (MyPlaceholderType == "Name")
            {
                MyPlaceholder = "請輸入姓名";
            }
            else if (MyPlaceholderType == "ID")
            {
                MyPlaceholder = "請輸入身分證字號";
            }
            else if (MyPlaceholderType == "Email")
            {
                MyPlaceholder = "請輸入電子郵件信箱";
            }
            else
            {
                MyPlaceholder = "";
            }
        }

        public bool 驗證身份證字號格式(string arg_Identify)
        {
            var d = false;
            if (arg_Identify.Length == 10)
            {
                arg_Identify = arg_Identify.ToUpper();
                if (arg_Identify[0] >= 0x41 && arg_Identify[0] <= 0x5A)
                {
                    var a = new[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                    var b = new int[11];
                    b[1] = a[(arg_Identify[0]) - 65] % 10;
                    var c = b[0] = a[(arg_Identify[0]) - 65] / 10;
                    for (var i = 1; i <= 9; i++)
                    {
                        b[i + 1] = arg_Identify[i] - 48;
                        c += b[i] * (10 - i);
                    }
                    if (((c % 10) + b[10]) % 10 == 0)
                    {
                        d = true;
                    }
                }
            }
            return d;
        }

        public bool 驗證電子郵件格式(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
    }
}
