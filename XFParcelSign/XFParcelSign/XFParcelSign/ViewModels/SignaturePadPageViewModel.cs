using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SignaturePad.Forms;
using XFParcelSign.Views;
using System.Threading.Tasks;

namespace XFParcelSign.ViewModels
{

    public class SignaturePadPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate Task GetImageDelegate();
        public GetImageDelegate OnGetImageDelegate;
        private readonly INavigationService _navigationService;

        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand ShowCommand { get; set; }



        public SignaturePadPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SubmitCommand = new DelegateCommand(async () =>
            {
                //var signedImageStream = await signPad.GetImageStreamAsync(SignatureImageFormat.Png);
                //if (signedImageStream != null) {
                //}
                if (OnGetImageDelegate != null)
                {
                    await OnGetImageDelegate();
                }
            });
            ShowCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("MainPage");
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

        }

    }

}
