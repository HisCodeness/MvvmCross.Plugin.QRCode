using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvxQrCode.Core;

namespace MvxQrCode.Android
{
    /// <summary>
    /// Setup class
    /// </summary>
    public class Setup : MvxAndroidSetup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationContext"></param>
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        /// <summary>
        /// Create the app
        /// </summary>
        /// <returns></returns>
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}