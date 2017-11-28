using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XFWebListView.Models;

namespace XFWebListView.Repositories
{
    public class ScenicSpotRepository
    {
        public static async Task Get()
        {
            // 這段程式碼為何不寫在建構式中
            #region 讀取網路上最新資料清單，並且顯示在螢幕上
            List<ScenicSpot> fooList = new List<ScenicSpot>();

            // 這裡需要加入 Microsoft.Net.Http & Newtonsoft.Json 兩個 NuGet 套件

            using (HttpClient client = new HttpClient())
            {
                // 使用非同步方式呼叫，並免應用程式畫面凍結
                var fooReslut = await client.GetStringAsync("http://data.moi.gov.tw/MoiOD/System/DownloadFile.aspx?DATA=D768074E-932A-4670-B908-0BE1402A7662");

                var fooScenicSpots = JsonConvert.DeserializeObject<List<ScenicSpot>>(fooReslut);
                foreach (var item in fooScenicSpots)
                {
                    fooList.Add(item);
                }
            }

            await Task.Delay(1000);
            #endregion

        }
    }
}
