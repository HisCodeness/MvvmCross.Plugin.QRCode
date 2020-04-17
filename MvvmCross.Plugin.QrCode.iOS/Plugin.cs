namespace MvvmCross.Plugin.QrCode.iOS
{
    /// <summary>
    /// Plugin
    /// </summary>
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        /// <summary>
        /// Load plugin
        /// </summary>
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IMvxQrCode>(new MvxQrCode());
        }
    }
}
