

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Activities;
using NavDrawer.Adapters;
using NavDrawer.Models;

namespace NavDrawer.Fragments
{
    public class BrowseFragment : Fragment
    {

        public BrowseFragment()
        {
            RetainInstance = true;
        }
		List<Monkey> friends;
        public override View OnCreateView(LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
			base.OnCreateView(inflater, container, savedInstanceState);

          	HasOptionsMenu = true;
            var view = inflater.Inflate(Resource.Layout.fragment_browse, null);

            var grid = view.FindViewById<GridView>(Resource.Id.grid);
            friends = Util.GenerateFriends();
            grid.Adapter = new MonkeyAdapter(Activity, friends);
            grid.ItemClick += GridOnItemClick;
            return view;
        }

        void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(Activity, typeof(FriendActivity));
            intent.PutExtra("Title", friends[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", friends[itemClickEventArgs.Position].Image);
            intent.PutExtra("Details", friends[itemClickEventArgs.Position].Details);
            StartActivity(intent);
        }

       
    }
}