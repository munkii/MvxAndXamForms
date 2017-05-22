using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace MvxAndXamForms.Droid
{
    using MvvmCross.Core.Views;
    using MvvmCross.Droid.Views;
    using MvvmCross.Forms.Presenter.Core;
    using MvvmCross.Forms.Presenter.Droid;
    using MvvmCross.Platform;
    using Xamarin.Forms;

    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new HybridPresenter();
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }
}
