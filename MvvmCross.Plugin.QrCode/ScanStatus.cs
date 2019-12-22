namespace MvvmCross.Plugin.QrCode
{
    /// <summary>
    /// Scan status
    /// </summary>
    public enum ScanStatus
    {
        /// <summary>
        /// Scan successful
        /// </summary>
        Success = 0,

        /// <summary>
        /// Scan canceled
        /// </summary>
        Canceled = 1,

        /// <summary>
        /// Scan ends with error
        /// </summary>
        Error = 666
    }
}