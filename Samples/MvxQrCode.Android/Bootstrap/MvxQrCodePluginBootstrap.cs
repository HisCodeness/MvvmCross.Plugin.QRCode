using MvvmCross.Platform.Plugins;

namespace MvxQrCode.Android.Bootstrap
{
    /// <summary>
    /// Plugin bootstrap
    /// </summary>
    public class MvxQrCodePluginBootstrap
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugin.QrCode.PluginLoader, MvvmCross.Plugin.QrCode.Android.Plugin>
    {
    }
}