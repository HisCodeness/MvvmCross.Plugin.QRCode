
using Android.App;
using MvvmCross.Droid.Views;

namespace MvxQrCode.Android
{
    [Activity(
            Label = "MvxQrCode"
            , MainLauncher = true
            , Icon = "@mipmap/ic_launcher"
            , Theme = "@style/AppTheme"
            , NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}