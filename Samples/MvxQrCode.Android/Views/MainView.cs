
using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvxQrCode.Core.ViewModels;

namespace MvxQrCode.Android.Views
{
    [Activity(Label = "MvxQrCode", Theme = "@style/AppTheme")]
    public class MainView : MvxActivity<MainViewModel>
    {
        /// <summary>
        /// Activity creation
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainActivity);
        }
    }
}