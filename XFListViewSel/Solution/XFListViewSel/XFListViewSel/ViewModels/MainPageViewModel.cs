using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XFListViewSel.Models;
using XFListViewSel.Repositories;

namespace XFListViewSel.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int SelectdQty { get; set; } = 0;
        public bool MultipleSelecte { get; set; } = false;
        public Product ProductSelected { get; set; }
        public ObservableCollection<Product> ProductsSource { get; set; } = new ObservableCollection<Product>();
        private readonly INavigationService _navigationService;

        public DelegateCommand ItemTappedCommand { get; set; }
        public DelegateCommand ToggledCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ToggledCommand = new DelegateCommand(() =>
            {
                ResetSelect();
            });

            ItemTappedCommand = new DelegateCommand(() =>
            {
                if (MultipleSelecte == false)
                {
                    ResetSelect();
                    ProductSelected.Selected = true;
                    SelectdQty = 1;
                }
                else
                {
                    if (ProductSelected.Selected == true)
                    {
                        SelectdQty -= 1;
                    }
                    else
                    {
                        SelectdQty += 1;
                    }
                    ProductSelected.Selected = !ProductSelected.Selected;
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
        var fooObjs = ProductRepsitory.GetProducts();
        foreach (var item in fooObjs)
        {
            ProductsSource.Add(item);
        }
    }

    public void ResetSelect()
    {
        foreach (var item in ProductsSource)
        {
            item.Selected = false;
        }
        SelectdQty = 0;
    }
}
}
