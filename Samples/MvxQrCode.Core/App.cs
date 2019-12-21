using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvxQrCode.Core.ViewModels;

namespace MvxQrCode.Core
{
    /// <summary>
    /// App class
    /// </summary>
    public class App : MvxApplication
    {
        /// <summary>
        /// Initialize App
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
