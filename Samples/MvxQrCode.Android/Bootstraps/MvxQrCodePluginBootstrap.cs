using MvvmCross.Platform.Plugins;

namespace MvxQrCode.Android.Bootstraps
{
    /// <summary>
    /// Plugin bootstrap
    /// </summary>
    public class MvxQrCodePluginBootstrap
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugin.QrCode.PluginLoader, MvvmCross.Plugin.QrCode.Android.Plugin>
    {
    }
}