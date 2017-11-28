using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFListViewSel.Models;

namespace XFListViewSel.Repositories
{
    public class ProductRepsitory
    {
        public static List<Product> GetProducts()
        {
            List<Product> fooMyTaskItems = new List<Product>();

            for (int i = 1; i < 100; i++)
            {
                var fooProd = new Product
                {
                    Id = i,
                    Name = $"產品名稱 {i}",
                    Description = $"產品說明 {i}",
                    Price = i * 99,
                    Selected = false,
                    SelectedColor = Color.LightSkyBlue,
                };
                if(i%2 == 0)
                {
                    fooProd.RowColor = Color.FromHex("#effff1");
                }
                else
                {
                    fooProd.RowColor = Color.FromHex("#d0e2d3");
                }
                fooMyTaskItems.Add(fooProd);
            }

            return fooMyTaskItems;
        }
    }
}
