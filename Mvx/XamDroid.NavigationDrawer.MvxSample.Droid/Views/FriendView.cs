using Android.App;
using Android.Support.V4.App;

using Cirrious.MvvmCross.Droid.Views;

namespace XamDroid.NavigationDrawer.MvxSample.Droid.Views
{
    [Activity(Label = "Friend", Theme = "@style/MyTheme", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "XamDroid.NavigationDrawer.MvxSample.Droid.Views.HomeView")]
    public class FriendView : MvxActivity
    {
    }
}