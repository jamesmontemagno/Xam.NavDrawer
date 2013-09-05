using Android.Views;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace XamDroid.NavigationDrawer.MvxSample.Droid.Views.Fragments
{
    public class ProfileView : MvxFragment
    {

        public ProfileView()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_profile, null);
        }
    }
}