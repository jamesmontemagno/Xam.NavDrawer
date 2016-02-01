using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;


using NavDrawer.Adapters;
using Android.Support.Design.Widget;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using NavDrawer.Core.ViewModels;
using Android.Runtime;

namespace NavDrawer.Fragments
{
	[MvxFragment(typeof(HomeViewModel), Resource.Id.content_frame)]
	[Register("navdrawer.fragments.FriendsFragment")]
	public class FriendsFragment : MvxFragment<FriendsViewModel>
    {
		ViewPager viewPager;
		FragmentPagerAdapter adapter;

        public FriendsFragment()
        {
            RetainInstance = true;
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_friends, null);

            // Create your application here
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.OffscreenPageLimit = 4;
			var tabs = view.FindViewById<TabLayout>(Resource.Id.tabs);
			tabs.TabMode = TabLayout.ModeScrollable;
            //Since we are a fragment in a fragment you need to pass down the child fragment manager!
            adapter = new FriendsAdapter (ChildFragmentManager);


			viewPager.Adapter = adapter;

			tabs.SetupWithViewPager(viewPager);
            return view;
        }

    }
}