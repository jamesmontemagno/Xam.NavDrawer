using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Adapters;
using NavDrawer.Models;
using UniversalImageLoader.Core;
using Android.Support.Design.Widget;
using Android.Support.V7.App;


using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace NavDrawer.Activities
{
    [Activity(Label = "Friend",ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "navdrawer.activities.HomeView")]
	public class FriendActivity : AppCompatActivity
    {
		List<FriendViewModel> friends;
		ImageLoader imageLoader;


        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            SetContentView(Resource.Layout.page_friend);
            imageLoader = ImageLoader.Instance;

						
            friends = Util.GenerateFriends();
            var title = Intent.GetStringExtra("Title");
            var image = Intent.GetStringExtra("Image");

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar (toolbar);

            if (string.IsNullOrWhiteSpace(image))
                image = friends[0].Image;

            SupportActionBar.SetDisplayHomeAsUpEnabled (true);

            var collapsingToolbar = FindViewById<CollapsingToolbarLayout> (Resource.Id.collapsing_toolbar);
            collapsingToolbar.SetTitle (title);

            imageLoader.DisplayImage(image, FindViewById<ImageView> (Resource.Id.friend_image));

            //var grid = FindViewById<GridView>(Resource.Id.grid);
            //grid.Adapter = new MonkeyAdapter(this, friends);
            //grid.ItemClick += GridOnItemClick;

          


        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(this, typeof(FriendActivity));
            intent.PutExtra("Title", friends[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", friends[itemClickEventArgs.Position].Image);
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)           
            {
                case Android.Resource.Id.Home:

					NavUtils.NavigateUpFromSameTask(this);

                    //Wrong:
                    //var intent = new Intent(this, typeof(HomeView));
                    //intent.AddFlags(ActivityFlags.ClearTop);
                    //StartActivity(intent);
                    

                    //if this could be launched externally:
                    
						/*var upIntent = NavUtils.GetParentActivityIntent(this);
						if (NavUtils.ShouldUpRecreateTask(this, upIntent))
						{
							// This activity is NOT part of this app's task, so create a new task
							// when navigating up, with a synthesized back stack.
							Android.Support.V4.App.TaskStackBuilder.Create(this).
								AddNextIntentWithParentStack(upIntent).StartActivities();
						}
						else
						{
							// This activity is part of this app's task, so simply
							// navigate up to the logical parent activity.
							NavUtils.NavigateUpTo(this, upIntent); 
						}*/
                     
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}