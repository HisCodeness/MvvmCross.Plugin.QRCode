using System.Threading.Tasks;

namespace MvvmCross.Plugin.QrCode.UnitTest.Fakes
{
    /// <summary>
    /// Null override
    /// </summary>
    internal class MvxQrCodeNull : BaseMvxQrCode
    {
        /// <summary>
        /// Returns null
        /// </summary>
        /// <param name="topText"></param>
        /// <param name="bottomText"></param>
        /// <param name="cameraUnsupportedMessage"></param>
        /// <returns></returns>
        protected override async Task<ZXing.Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            await Task.Delay(1);
            return null;
        }
    }
}
