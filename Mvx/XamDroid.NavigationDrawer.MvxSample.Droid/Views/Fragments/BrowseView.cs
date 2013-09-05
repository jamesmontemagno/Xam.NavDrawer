using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

namespace XamDroid.NavigationDrawer.MvxSample.Droid.Views.Fragments
{
    public class BrowseView : MvxFragment
    {
        public BrowseView()
        {
            RetainInstance = true;
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_browse, null);
        }
    }
}