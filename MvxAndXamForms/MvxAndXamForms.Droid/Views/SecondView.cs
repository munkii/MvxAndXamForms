using Android.App;
using Android.OS;

namespace MvxAndXamForms.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.SecondView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
