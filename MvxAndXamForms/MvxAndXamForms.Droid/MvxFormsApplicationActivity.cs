using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MvxAndXamForms.Droid
{
    using Android.Content.PM;
    using Core;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Core.Views;
    using MvvmCross.Droid.Platform;
    using MvvmCross.Droid.Views;
    using MvvmCross.Forms.Presenter.Core;
    using MvvmCross.Forms.Presenter.Droid;
    using MvvmCross.Platform;
    using MvvmCross.Platform.Droid.Platform;
    using Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    [Activity(Label = "Mvx Forms Application Activity", ScreenOrientation = ScreenOrientation.Portrait, NoHistory = false)]
    public class MvxFormsApplicationActivity : FormsApplicationActivity
    {
        private IMvxAndroidActivityLifetimeListener _lifetimeListener;
        private IMvxAndroidActivityLifetimeListener LifetimeListener
        {
            get
            {
                if (_lifetimeListener == null)
                {
                    _lifetimeListener = Mvx.Resolve<IMvxAndroidActivityLifetimeListener>();
                }

                return _lifetimeListener;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            
            HybridPresenter presenter = Mvx.Resolve<IMvxViewPresenter>() as HybridPresenter;
            
            LoadApplication(presenter.MvxFormsApp);

            ////this.Title = "MvxForms Host";

            LifetimeListener.OnCreate(this);
        }

        protected override void OnStart()
        {
            base.OnStart();

            LifetimeListener.OnStart(this);
        }

        protected override void OnStop()
        {
            base.OnStop();

            LifetimeListener.OnStop(this);
        }

        protected override void OnResume()
        {
            base.OnResume();

            LifetimeListener.OnResume(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            LifetimeListener.OnDestroy(this);
        }

        protected override void OnPause()
        {
            base.OnPause();

            LifetimeListener.OnPause(this);
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            LifetimeListener.OnRestart(this);
        }
    }
}