using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;using MvvmCross.Wpf.Views;
using MvxAndXamForms.Core.ViewModels;

namespace MvxAndXamForms.WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using MvvmCross.Platform;
    using Xamarin.Forms;
    using Application = Xamarin.Forms.Application;

    public class HybridPresenter : MvxSimpleWpfViewPresenter
    {
        private Application mvxFormsApp;

        public Application MvxFormsApp
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

        public HybridPresenter(ContentControl contentControl) : base (contentControl)
        {
        }
        
        public override void Show(MvxViewModelRequest request)
        {
            if (request.ViewModelType == typeof(ThirdViewModel) || request.ViewModelType == typeof(FourthViewModel))
            {

                var contentPage = MvxPresenterHelpers.CreatePage(request);
                //set DataContext of page to LoadViewModel
                var viewModel = MvxPresenterHelpers.LoadViewModel(request);

                contentPage.BindingContext = viewModel;
                //use CreateViewController 

                var mainPage = _mvxFormsApp.MainPage as NavigationPage;

                if (mainPage == null)
                {
                    _mvxFormsApp.MainPage = new NavigationPage(contentPage);
                    mainPage = MvxFormsApp.MainPage as NavigationPage;
             }
                else
                {
                    try
                    {
                        // check for modal presentation parameter
                        string modalParameter;
                        if (request.PresentationValues != null && request.PresentationValues.TryGetValue(ModalPresentationParameter, out modalParameter) && bool.Parse(modalParameter))
                            mainPage.Navigation.PushModalAsync(page);
                        else
                            // calling this sync blocks UI and never navigates hence code continues regardless here
                            mainPage.PushAsync(page);
                    }
                    catch (Exception e)
                    {
                        Mvx.Error("Exception pushing {0}: {1}\n{2}", page.GetType(), e.Message, e.StackTrace);
                        return false;
                    }
                }

                return true;

            }
            else
            {
                base.Show(request);
            }
        }
    }
}
