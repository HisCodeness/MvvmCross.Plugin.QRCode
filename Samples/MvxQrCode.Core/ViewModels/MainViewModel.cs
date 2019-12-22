using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugin.QrCode;

namespace MvxQrCode.Core.ViewModels
{
    /// <summary>
    /// Main view model
    /// </summary>
    public class MainViewModel : MvxViewModel
    {
        /// <summary>
        /// QR code Service
        /// </summary>
        private readonly IMvxQrCode mvxQrCode;

        /// <summary>
        /// Result
        /// </summary>
        private string text = "Result will be displayed here";

        /// <summary>
        /// Scan label
        /// </summary>
        public string ScanLabel { get { return "Scan"; } }

        /// <summary>
        /// Result
        /// </summary>
        public string Result
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mvxQrCode"></param>
        public MainViewModel(IMvxQrCode mvxQrCode)
        {
            this.mvxQrCode = mvxQrCode;
        }

        /// <summary>
        /// Scan command
        /// </summary>
        public IMvxAsyncCommand ScanCommand => new MvxAsyncCommand(ScanCommandExecute);

        /// <summary>
        /// Scan command execute
        /// </summary>
        private async Task ScanCommandExecute()
        {
            var scanResult = await mvxQrCode.Scan("Hold the camera up to the barcode\nAbout 15 cm away",
                                    "The barcode will be automatically scanned",
                                    "Your camera doesn't support barcode scanning");

            switch (scanResult.ScanStatus)
            {
                case ScanStatus.Success:
                    Result = scanResult.Result.Text;
                    break;
                case ScanStatus.Canceled:
                    Result = "Scan canceled";
                    break;
                case ScanStatus.Error:
                    Result = scanResult.Exception.Message;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
