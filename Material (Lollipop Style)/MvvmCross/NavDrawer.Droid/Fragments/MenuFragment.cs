using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using NavDrawer.Core.ViewModels;
using Cirrious.MvvmCross.Droid.FullFragging;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using NavDrawer.Droid;

namespace NavDrawer.Fragments
{
    [MvxOwnedViewModelFragment]
    [Register("navdrawer.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(NavDrawer.Droid.Resource.Layout.fragment_menu, null);
        }
    }
}