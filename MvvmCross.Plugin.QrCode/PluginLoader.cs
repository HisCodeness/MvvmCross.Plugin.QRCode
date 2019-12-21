using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvmCross.Plugin.QrCode
{
    /// <summary>
    /// Plugin loader
    /// </summary>
    public class PluginLoader : IMvxPluginLoader
    {
        /// <summary>
        /// Plugin loader instance
        /// </summary>
        public static readonly PluginLoader Instance = new PluginLoader();

        /// <summary>
        /// Ensure the plugin is loaded
        /// </summary>
        public void EnsureLoaded()
        {
            var manager = Mvx.Resolve<IMvxPluginManager>();
            manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
        }
    }
}
