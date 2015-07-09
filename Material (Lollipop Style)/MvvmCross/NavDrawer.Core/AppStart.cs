using System;
using Cirrious.MvvmCross.ViewModels;

namespace NavDrawer.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        /// <summary>
        /// Start is called on startup of the app
        /// Hint contains information in case the app is started with extra parameters
        /// </summary>
        public void Start(object hint = null)
        {
            ShowViewModel<ViewModels.HomeViewModel>();
        }
    }
}

