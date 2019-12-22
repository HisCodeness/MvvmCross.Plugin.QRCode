using System;
using System.Threading.Tasks;

namespace MvvmCross.Plugin.QrCode
{
    /// <summary>
    /// Mvx QR code plugin base implementation
    /// </summary>
    public abstract class BaseMvxQrCode : IMvxQrCode
    {
        /// <summary>
        /// Open the camera and scan until a QR Code is found
        /// </summary>
        /// <param name="topText">Text displayed at the top of the layout</param>
        /// <param name="bottomText">Text displayed at the bottom of the layout</param>
        /// <param name="cameraUnsupportedMessage">Unsupported camera message</param>
        /// <returns>Scan result</returns>
        public async Task<ScanResult> Scan(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            var scanResult = new ScanResult();
            try
            {
                scanResult.Result = await ScanNative(topText, bottomText, cameraUnsupportedMessage);
                if (scanResult.Result == default || string.IsNullOrEmpty(scanResult.Result.Text))
                {
                    scanResult.ScanStatus = ScanStatus.Canceled;
                }
            }
            catch (Exception ex)
            {
                scanResult.Exception = ex;
                scanResult.ScanStatus = ScanStatus.Error;
            }

            return scanResult;
        }

        /// <summary>
        /// Native implementation of scan
        /// </summary>
        /// <param name="topText">Text displayed at the top of the layout</param>
        /// <param name="bottomText">Text displayed at the bottom of the layout</param>
        /// <param name="cameraUnsupportedMessage">Unsupported camera message</param>
        /// <returns>Native scan result</returns>
        protected abstract Task<ZXing.Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage);
    }
}
