using MvvmCross.Core.ViewModels;

namespace MvxAndXamForms.Core.ViewModels
{
    using System.Diagnostics;

    [ViewFromXamarinForms]
    public class ThirdViewModel : MvxViewModel
    {
        private double value = 0.54;
        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                Debug.WriteLine("Set Value to :" + value);
                SetProperty(ref this.value, value);
            }
        }

        public MvxCommand SaveCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("Save data*************************");
                    this.Close(this);
                });
            }
        }

        public MvxCommand GoToFourthCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    this.ShowViewModel(typeof(FourthViewModel));
                });
            }
        }
    }
}
