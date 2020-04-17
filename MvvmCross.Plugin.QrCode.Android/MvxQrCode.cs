using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content.Res;
using MvvmCross.Platforms.Android;
using ZXing.Mobile;
using static ZXing.Mobile.MobileBarcodeScanningOptions;

namespace MvvmCross.Plugin.QrCode.Android
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
            // Current activity
            var currentActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

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
                // Add option for use correct resolution for mobile
                var options = new MobileBarcodeScanningOptions()
                {
                    CameraResolutionSelector = new CameraResolutionSelectorDelegate(ResolutionSelector)
                };

                // Start scanning
                return await scanner.Scan(options);
            }
            finally
            {

                // Uninitialize the scanner to avoid memory leaks
                MobileBarcodeScanner.Uninitialize(currentActivity.Application);
            }
        }

        /// <summary>
        /// Select the resolution who fit to the screen size
        /// </summary>
        /// <param name="availableResolutions"></param>
        /// <returns></returns>
        private CameraResolution ResolutionSelector(List<CameraResolution> availableResolutions)
        {
            // Get current width and height
            var currentActivity = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var height = currentActivity.Window.DecorView.Height;
            var width = currentActivity.Window.DecorView.Width;

            //a tolerance of 0.1 should not be visible to the user
            double aspectTolerance = 0.1;
            var displayOrientationHeight = currentActivity.Resources.Configuration.Orientation == Orientation.Portrait ? (double)height : width;
            var displayOrientationWidth = currentActivity.Resources.Configuration.Orientation == Orientation.Portrait ? (double)width : height;

            //Get the target resolution
            var targetRatio = displayOrientationHeight / displayOrientationWidth;
            return availableResolutions.FirstOrDefault(r => (Math.Abs((double)r.Width / r.Height) - targetRatio) < aspectTolerance);
        }
    }
}