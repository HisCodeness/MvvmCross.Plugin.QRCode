using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvxQrCode.Core;
using UIKit;

namespace MvxQrCode.iOS
{
    /// <summary>
    /// Setup
    /// </summary>
    public class Setup : MvxIosSetup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationDelegate"></param>
        /// <param name="window"></param>
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationDelegate"></param>
        /// <param name="presenter"></param>
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        /// <summary>
        /// Application creation
        /// </summary>
        /// <returns></returns>
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}