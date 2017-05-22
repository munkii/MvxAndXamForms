using MvvmCross.Core.ViewModels;

namespace MvxAndXamForms.Core.ViewModels
{
    using System.Diagnostics;

    [ViewFromXamarinForms]
    public class FourthViewModel : MvxViewModel
    {
        public MvxCommand DoneCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Debug.WriteLine("Done************************");
                    this.Close(this);
                });
            }
        }
    }
}
