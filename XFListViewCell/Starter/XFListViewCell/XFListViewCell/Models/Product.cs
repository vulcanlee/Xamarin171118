using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XFListViewCell.Models
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
