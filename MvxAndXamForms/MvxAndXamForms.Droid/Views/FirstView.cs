using Android.App;
using Android.OS;

namespace MvxAndXamForms.Droid.Views
{
    [Activity(Label = "Is this a Title? Label??")]
    public class FirstView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
