using MvvmCross.Core.ViewModels;

namespace MvxAndXamForms.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        string hello = "Welcome From First ViewModel";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

        public MvxCommand GoToSecondVm
        {
            get
            {
                return new MvxCommand(() =>
                {
                    this.ShowViewModel(typeof(SecondViewModel));
                });
            }
        }
    }
}
