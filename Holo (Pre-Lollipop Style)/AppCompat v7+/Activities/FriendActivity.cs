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
using Android.Support.V7.App;

namespace NavDrawer.Activities
{
    [Activity(Label = "Friend", Theme = "@style/MyTheme",
	          Icon = "@android:color/transparent")]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "navdrawer.activities.HomeView")]
	public class FriendActivity : ActionBarActivity
    {
        private List<FriendViewModel> _friends;
        private ImageLoader m_ImageLoader;
        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friend);
            m_ImageLoader = new ImageLoader(this);

			this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			this.SupportActionBar.SetHomeButtonEnabled(true);

            _friends = Util.GenerateFriends();
            _friends.RemoveRange(0, _friends.Count - 2);
            var title = Intent.GetStringExtra("Title");
            var image = Intent.GetStringExtra("Image");

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            this.Title = title;

            if (string.IsNullOrWhiteSpace(image))
                image = _friends[0].Image;


            m_ImageLoader.DisplayImage(image, this.FindViewById<ImageView>(Resource.Id.friend_image), -1);
            this.FindViewById<TextView>(Resource.Id.friend_description).Text = title;

            var grid = FindViewById<GridView>(Resource.Id.grid);
            grid.Adapter = new MonkeyAdapter(this, _friends);
            grid.ItemClick += GridOnItemClick;

            //set title here
        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(this, typeof(FriendActivity));
            intent.PutExtra("Title", _friends[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", _friends[itemClickEventArgs.Position].Image);
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)           
            {
			case Resource.Id.home:

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