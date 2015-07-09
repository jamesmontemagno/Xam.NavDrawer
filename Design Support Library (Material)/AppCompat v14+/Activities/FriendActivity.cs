using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Adapters;
using NavDrawer.Models;

using com.refractored.monodroidtoolkit.imageloader;

namespace NavDrawer.Activities
{
    [Activity(Label = "Friend",ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "navdrawer.activities.HomeView")]
	public class FriendActivity : BaseActivity
    {
		List<FriendViewModel> friends;
		ImageLoader imageLoader;

				protected override int LayoutResource {
					get {
						return Resource.Layout.page_friend;
					}
				}

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
			imageLoader = new ImageLoader(this, 128);

						
            friends = Util.GenerateFriends();
            friends.RemoveRange(0, friends.Count - 2);
            var title = Intent.GetStringExtra("Title");
            var image = Intent.GetStringExtra("Image");

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            Title = title;

            if (string.IsNullOrWhiteSpace(image))
                image = friends[0].Image;


            imageLoader.DisplayImage(image, FindViewById<ImageView> (Resource.Id.friend_image), -1);
            FindViewById<TextView> (Resource.Id.friend_description).Text = title;

            var grid = FindViewById<GridView>(Resource.Id.grid);
            grid.Adapter = new MonkeyAdapter(this, friends);
            grid.ItemClick += GridOnItemClick;

            //set title here
						SupportActionBar.Title = Title;
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