using System;
using Xamarin.Forms;
using SignaturePad.Forms;
using PCLStorage;
using XFParcelSign.ViewModels;
using System.Threading.Tasks;

namespace XFParcelSign.Views
{
    public partial class SignaturePadPage : ContentPage
    {
        SignaturePadPageViewModel fooSignaturePadPageViewModel;
        public SignaturePadPage()
        {
            InitializeComponent();

            fooSignaturePadPageViewModel =
                this.BindingContext as SignaturePadPageViewModel;
            fooSignaturePadPageViewModel.OnGetImageDelegate = OnGetImage;
        }

        private async Task OnGetImage()
        {
            var settings = new ImageConstructionSettings
            {
                Padding = 12,
                StrokeColor = Color.FromRgb(25, 25, 25),
                BackgroundColor = Color.FromRgb(225, 225, 225),
                DesiredSizeOrScale = 2f
            };
            var image = await padView.GetImageStreamAsync(SignatureImageFormat.Png, settings);

            if (image == null)
                return;




            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MySubFolder",
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("answer.png",
                CreationCollisionOption.ReplaceExisting);
            using (var fooStream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                await image.CopyToAsync(fooStream);
            }



            //var page = new ContentPage
            //{
            //    Title = "Signature",
            //    Content = new Image
            //    {
            //        Aspect = Aspect.AspectFit,
            //        Source = ImageSource.FromStream(() => image)
            //    }
            //};

            //await Navigation.PushAsync(page);
        }
    }
}
