using System.Threading.Tasks;
using ZXing;

namespace MvvmCross.Plugin.QrCode.UnitTest.Fakes
{
    /// <summary>
    /// Success override
    /// </summary>
    internal class MvxQrCodeSuccess : BaseMvxQrCode
    {
        /// <summary>
        /// Success label returned
        /// </summary>
        internal const string ResultLabel = "Success";

        /// <summary>
        /// Returns success
        /// </summary>
        /// <param name="topText"></param>
        /// <param name="bottomText"></param>
        /// <param name="cameraUnsupportedMessage"></param>
        /// <returns></returns>
        protected override async Task<Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            await Task.Delay(1);
            return new ZXing.Result(ResultLabel, new byte[0], null, ZXing.BarcodeFormat.QR_CODE);
        }
    }
}