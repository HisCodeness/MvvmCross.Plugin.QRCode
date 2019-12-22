using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using ZXing.Mobile;

namespace MvvmCross.Plugin.QrCode.Android
{
    /// <summary>
    /// Mvx QR code plugin implementation
    /// </summary>
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
            // Current activity
            var currentActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            // Initialize the scanner first so we can track the current context
            MobileBarcodeScanner.Initialize(currentActivity.Application);

            // Create a new instance of our scanner
            var scanner = new MobileBarcodeScanner
            {
                UseCustomOverlay = false, // Use the default overlay
                TopText = topText,
                BottomText = bottomText,
                CameraUnsupportedMessage = cameraUnsupportedMessage
            };

            try
            {
                // Start scanning
                return await scanner.Scan();
            }
            finally
            {
                // Uninitialize the scanner to avoid memory leaks
                MobileBarcodeScanner.Uninitialize(currentActivity.Application);
            }
        }
    }
}