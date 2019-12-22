using System;
using System.Threading.Tasks;

namespace MvvmCross.Plugin.QrCode.UnitTest.Fakes
{
    /// <summary>
    /// Error override
    /// </summary>
    internal class MvxQrCodeError : BaseMvxQrCode
    {
        /// <summary>
        /// Label returned
        /// </summary>
        internal const string ErrorLabel = "Exception";

        /// <summary>
        /// Throws <see cref="NotSupportedException"/>
        /// </summary>
        /// <param name="topText"></param>
        /// <param name="bottomText"></param>
        /// <param name="cameraUnsupportedMessage"></param>
        /// <returns></returns>
        protected override Task<ZXing.Result> ScanNative(string topText, string bottomText, string cameraUnsupportedMessage)
        {
            throw new NotSupportedException(ErrorLabel);
        }
    }
}