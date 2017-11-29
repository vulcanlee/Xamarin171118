using System;
using System.Collections.Generic;
using System.Text;
using XFListViewCell.Models;

namespace XFListViewCell.Repositories
{
    public class ProductRepository
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
                     Qty = 0,
                };
                fooMyTaskItems.Add(fooProd);
            }

            return fooMyTaskItems;
        }
    }
}
