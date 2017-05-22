using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace MvxAndXamForms.Droid
{
    using Android.OS;
    using MvvmCross.Core.Views;
    using MvvmCross.Forms.Presenter.Core;
    using MvvmCross.Platform;
    using Xamarin.Forms;

    [Activity(
        Label = "MvxAndXamForms"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);

            var mvxFormsApp = new MvxFormsApp();

            HybridPresenter presenter = Mvx.Resolve<IMvxViewPresenter>() as HybridPresenter;
            presenter.MvxFormsApp = mvxFormsApp;
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
