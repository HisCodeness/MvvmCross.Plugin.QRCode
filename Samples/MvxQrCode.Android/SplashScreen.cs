using Android.App;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace MvxQrCode.Android
{
    [Activity(
            Label = "MvxQrCode"
            , MainLauncher = true
            , Icon = "@mipmap/ic_launcher"
            , Theme = "@style/AppTheme"
            , NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<Core.App>, Core.App>
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