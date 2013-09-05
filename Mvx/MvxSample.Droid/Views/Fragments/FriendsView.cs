using System.Collections.Generic;

using Android.OS;
using Android.Support.V4.View;

using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;

using DK.Ostebaronen.Droid.ViewPagerIndicator;

using MvxSample.Core.ViewModels.Friends;
using MvxSample.Droid.Views.Adapters;

namespace MvxSample.Droid.Views.Fragments
{
    public class FriendsView : MvxFragment
    {
        private FriendsViewModel m_ViewModel;

        public new FriendsViewModel ViewModel
        {
            get { return this.m_ViewModel ?? (this.m_ViewModel = base.ViewModel as FriendsViewModel); }
        }

         private ViewPager m_ViewPager;
        private TabPageIndicator m_PageIndicator;
        private MvxViewPagerFragmentAdapter m_Adapter;

        public FriendsView()
        {
            this.RetainInstance = true;
        }

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.fragment_friends, null);

            // Create your application here
            this.m_ViewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            this.m_ViewPager.OffscreenPageLimit = 4;
            this.m_PageIndicator = view.FindViewById<TabPageIndicator>(Resource.Id.viewPagerIndicator);


            var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
              {
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                  FragmentType = typeof(FriendsAllView),
                  Title = "All",
                  ViewModel = this.ViewModel.FriendsAllViewModel
                },
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                  FragmentType = typeof(FriendsRecentView),
                  Title = "Recent",
                  ViewModel = this.ViewModel.FriendsRecentViewModel
                }
              };


            this.m_Adapter = new MvxViewPagerFragmentAdapter(this.Activity, this.ChildFragmentManager, fragments);
            this.m_ViewPager.Adapter = this.m_Adapter;

            this.m_PageIndicator.SetViewPager(this.m_ViewPager);
            this.m_PageIndicator.CurrentItem = 0;
            return view;
        }




    }
}