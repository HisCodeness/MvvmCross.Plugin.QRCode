using System.Threading.Tasks;

namespace MvvmCross.Plugin.QrCode.UnitTest.Fakes
{
    /// <summary>
    /// Default override
    /// </summary>
    internal class MvxQrCodeDefault : BaseMvxQrCode
    {
        /// <summary>
        /// Return default result
        /// </summary>
        /// <param name="topText"></param>
        /// <param name="bottomText"></param>
        /// <param name="cameraUnsupportedMessage"></param>
        /// <returns></returns>
        protected override async Task<ZXing.Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            await Task.Delay(1);
            return new ZXing.Result("", new byte[0], null, ZXing.BarcodeFormat.QR_CODE);
        }
    }
}
