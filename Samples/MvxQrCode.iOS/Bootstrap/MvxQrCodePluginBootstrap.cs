using MvvmCross.Platform.Plugins;

namespace MvxQrCode.iOS.Bootstrap
{
    /// <summary>
    /// Plugin bootstrap
    /// </summary>
    public class MvxQrCodePluginBootstrap
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugin.QrCode.PluginLoader, MvvmCross.Plugin.QrCode.iOS.Plugin>
    {
    }
}