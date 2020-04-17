using System.Linq;
using System.Threading.Tasks;
using UIKit;
using ZXing.Mobile;

namespace MvvmCross.Plugin.QrCode.iOS
{
    /// <summary>
    /// Mvx QR code plugin implementation
    /// </summary>
    [Preserve(AllMembers = true)]
    public class MvxQrCode : BaseMvxQrCode
    {
        /// <summary>
        /// Native implementation of scan
        /// </summary>
        /// <param name="topText">Text displayed at the top of the layout</param>
        /// <param name="bottomText">Text displayed at the bottom of the layout</param>
        /// <param name="cameraUnsupportedMessage">Unsupported camera message</param>
        /// <returns>Native scan result</returns>
        protected override async Task<ZXing.Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            // Current controller
            var currentController = GetTopViewController();

            // Create a new instance of our scanner
            var scanner = new MobileBarcodeScanner(currentController)
            {
                UseCustomOverlay = false, // Use the default overlay
                TopText = topText,
                BottomText = bottomText,
                CameraUnsupportedMessage = cameraUnsupportedMessage
            };

            // Start scanning
            return await scanner.Scan();
        }

        /// <summary>
        /// Look for the top view controller
        /// </summary>
        /// <returns></returns>
        private static UIViewController GetTopViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var rootViewController = window.RootViewController;
            while (rootViewController.PresentedViewController != null)
            {
                rootViewController = rootViewController.PresentedViewController;
            }

            if (rootViewController is UINavigationController navController)
            {
                rootViewController = navController.ViewControllers.Last();
            }

            return rootViewController;
        }
    }
}