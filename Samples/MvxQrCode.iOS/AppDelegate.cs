using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace MvxQrCode.iOS
{
    /// <summary>
    /// App delegate
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        /// <summary>
        /// Main window
        /// </summary>
        public override UIWindow Window { get; set; }

        /// <summary>
        /// Finished launching
        /// </summary>
        /// <param name="application"></param>
        /// <param name="launchOptions"></param>
        /// <returns></returns>
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
