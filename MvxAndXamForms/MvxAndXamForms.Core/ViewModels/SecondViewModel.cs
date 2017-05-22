using MvvmCross.Core.ViewModels;

namespace MvxAndXamForms.Core.ViewModels
{
    public class SecondViewModel
        : MvxViewModel
    {
        string hello = "Welcome From Second ViewModel";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

        public MvxCommand GoToThirdVm
        {
            get
            {
                return new MvxCommand(() =>
                {
                    this.ShowViewModel(typeof(ThirdViewModel));
                });
            }
        }
    }
}
