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
        public IMvxCommand ScanCommand => new MvxCommand(ScanCommandExecute);

        /// <summary>
        /// Scan command execute
        /// </summary>
        private void ScanCommandExecute()
        {
            // TODO call IMvxQrCode
            Result = mvxQrCode.Scan();
        }
    }
}
