using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvmCross.Plugin.QrCode.iOS
{
    /// <summary>
    /// Plugin
    /// </summary>
    public class Plugin : IMvxPlugin
    {
        /// <summary>
        /// Load plugin
        /// </summary>
        public void Load()
        {
            Mvx.RegisterSingleton<IMvxQrCode>(new MvxQrCode());
        }
    }
}
