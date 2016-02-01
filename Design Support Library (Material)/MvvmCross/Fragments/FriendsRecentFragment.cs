using System;
using System.Collections.Generic;

using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Activities;
using NavDrawer.Adapters;
using NavDrawer.Models;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using NavDrawer.Core.ViewModels;
using Android.Runtime;

namespace NavDrawer.Fragments
{
	[MvxFragment(typeof(HomeViewModel), Resource.Id.content_frame)]
	[Register("navdrawer.fragments.FriendsRecentFragment")]
	public class FriendsRecentFragment : MvxFragment<FriendsRecentViewModel>
    {
        public FriendsRecentFragment()
        {
            RetainInstance = true;
        }

		private List<Monkey> friends;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_friends_recent, null);
            var grid = view.FindViewById<GridView>(Resource.Id.grid);
            friends = Util.GenerateFriends();
            friends.RemoveRange(0, friends.Count - 4);
            grid.Adapter = new MonkeyAdapter(Activity, friends);

            grid.ItemClick += GridOnItemClick;
            return view;
        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(Activity, typeof(FriendActivity));
            intent.PutExtra("Title", friends[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", friends[itemClickEventArgs.Position].Image);
            StartActivity(intent);
        }
    }
}