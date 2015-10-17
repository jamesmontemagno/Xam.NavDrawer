using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;

using NavDrawer.Fragments;
using Android.Support.Design.Widget;
using UniversalImageLoader.Core;

namespace NavDrawer.Activities
{
	[Activity (Label = "Nav Drawer", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/ic_launcher")]
	public class HomeView : BaseActivity
	{
		DrawerLayout drawerLayout;
		NavigationView navigationView;

		protected override int LayoutResource {
			get {
				return Resource.Layout.page_home_view;
			}
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            var config = ImageLoaderConfiguration.CreateDefault(ApplicationContext);
            // Initialize ImageLoader with configuration.
            ImageLoader.Instance.Init(config);

			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);

			SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
			navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			navigationView.NavigationItemSelected += (sender, e) => {
				e.MenuItem.SetChecked (true);

				switch(e.MenuItem.ItemId)
				{
				case Resource.Id.nav_home:
					ListItemClicked(0);
					break;
				case Resource.Id.nav_friends:
					ListItemClicked(1);
					break;
				case Resource.Id.nav_profile:
					ListItemClicked(2);
					break;
				}

				

				drawerLayout.CloseDrawers ();
			};

			//if first time you will want to go ahead and click first item.
			if (savedInstanceState == null) {
				ListItemClicked (0);
			}
		}

		private void ListItemClicked (int position)
		{
			Android.Support.V4.App.Fragment fragment = null;
			switch (position) {
			case 0:
				fragment = new BrowseFragment ();
				break;
			case 1:
				fragment = new FriendsFragment ();
				break;
			case 2:
				fragment = new ProfileFragment ();
				break;
			}

			SupportFragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragment)
				.Commit ();
		}

	

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Android.Resource.Id.Home:
				drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}
	}
}

