using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;
using XFEADeviceID.EventAggregators;

namespace XFEADeviceID.Droid
{
    [Activity(Label = "XFEADeviceID", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        IUnityContainer myContainer;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            myContainer = (App.Current as PrismApplication).Container;
            var fooEvengAggregator = myContainer.Resolve<IEventAggregator>();
            fooEvengAggregator.GetEvent<DevicdIDEvent>().Subscribe(x =>
            {
                var fooResult = Android.OS.Build.Serial;
                fooEvengAggregator.GetEvent<DevicdIDResponseEvent>().Publish(new DevicdIDResponsePayload()
                {
                    Message = fooResult,
                });
            });
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            // Register any platform specific implementations
        }
    }
}

