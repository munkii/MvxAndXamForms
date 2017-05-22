using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MvxAndXamForms.iOS
{
    using Core;
    using Core.ViewModels;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Forms.Presenter.Core;
    using MvvmCross.iOS.Views.Presenters;
    using MvvmCross.Platform;
    using Xamarin.Forms;

    public class HybridPresenter : MvxIosViewPresenter
    {   public HybridPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window, MvxFormsApp mvxFormsApp) : base (applicationDelegate, window)
        {
            this.MvxFormsApp = mvxFormsApp;
        }

        private Xamarin.Forms.Application mvxFormsApp;

        public Xamarin.Forms.Application MvxFormsApp
        {
            get { return this.mvxFormsApp; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("MvxFormsApp cannot be null");
                }

                this.mvxFormsApp = value;
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            this.MasterNavigationController.PopViewController(true);
        }

        public override void Show(MvxViewModelRequest request)
        {
            var viewFromXf = request.ViewModelType.GetCustomAttributes(typeof(ViewFromXamarinFormsAttribute), false);

            if (viewFromXf.Any())
            {
                var contentPage = MvxPresenterHelpers.CreatePage(request);
                //set DataContext of page to LoadViewModel
                var viewModel = MvxPresenterHelpers.LoadViewModel(request);

                contentPage.BindingContext = viewModel;
                
                var mainPage = this.MvxFormsApp.MainPage as NavigationPage;

                if (mainPage == null)
                {
                    this.MvxFormsApp.MainPage = new NavigationPage(contentPage);
                    mainPage = MvxFormsApp.MainPage as NavigationPage;
                }

                UIViewController vc = contentPage.CreateViewController();

                vc.NavigationItem.Title = contentPage.Title;

                if (this.MasterNavigationController == null)
                {
                    _window.RootViewController = vc;
                }
                else
                {
                    
                    this.MasterNavigationController.PushViewController(vc, true);
                }
            }
            else
            {
                base.Show(request);
            }
        }
    }
}
