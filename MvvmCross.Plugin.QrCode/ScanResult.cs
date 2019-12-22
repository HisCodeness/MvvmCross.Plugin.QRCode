using System;

namespace MvvmCross.Plugin.QrCode
{
    /// <summary>
    /// Scan result
    /// </summary>
    public struct ScanResult
    {
        /// <summary>
        /// Scan status
        /// </summary>
        public ScanStatus ScanStatus { get; set; }

        /// <summary>
        /// QR Code full content, if <see cref="ScanStatus"/> is not <see cref="ScanStatus.Success"/> this property could null
        /// </summary>
        public ZXing.Result Result { get; set; }

        /// <summary>
        /// Optional exception if <see cref="ScanStatus"/> is <see cref="ScanStatus.Error"/>, otherwise this property is null
        /// </summary>
        public Exception Exception { get; set; }
    }
}
