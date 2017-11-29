using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFListViewCell.Models;
using XFListViewCell.Repositories;

namespace XFListViewCell.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Product> ProductsSource { get; set; } = new ObservableCollection<Product>();
        public int TotalPrice { get; set; } = 0;
        public DelegateCommand ComputeCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ComputeCommand = new DelegateCommand(() =>
            {
                TotalPrice = 0;
                foreach (var item in ProductsSource)
                {
                    TotalPrice += item.Price * item.Qty;
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var fooList = ProductRepository.GetProducts();
            foreach (var item in fooList)
            {
                ProductsSource.Add(item);
            }
        }

    }
}
