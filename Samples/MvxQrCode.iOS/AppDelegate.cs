using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvxQrCode.Core;

namespace MvxQrCode.iOS
{
    /// <summary>
    /// App delegate
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
    {
    }
}
