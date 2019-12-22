using System.Threading.Tasks;

namespace MvvmCross.Plugin.QrCode
{
    /// <summary>
    /// QR Code plugin interface
    /// </summary>
    public interface IMvxQrCode
    {
        /// <summary>
        /// Open the camera and scan until a QR Code is found
        /// </summary>
        /// <param name="topText">Text displayed at the top of the layout</param>
        /// <param name="bottomText">Text displayed at the bottom of the layout</param>
        /// <param name="cameraUnsupportedMessage">Unsupported camera message</param>
        /// <returns>Scan result, <see cref="ScanResult"/></returns>
        Task<ScanResult> Scan(string topText, string bottomText, string cameraUnsupportedMessage);
    }
}
