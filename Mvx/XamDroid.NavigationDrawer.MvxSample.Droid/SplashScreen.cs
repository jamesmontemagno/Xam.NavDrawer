using Android.App;
using Android.Content.PM;

using Cirrious.MvvmCross.Droid.Views;

namespace XamDroid.NavigationDrawer.MvxSample.Droid
{
    [Activity(
       Label = "cameroon.ui.android"
       , MainLauncher = true
       , Icon = "@drawable/ic_launcher"
       , Theme = "@style/Theme.Splash"
       , NoHistory = true
       , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
