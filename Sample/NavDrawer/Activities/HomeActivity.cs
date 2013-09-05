using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using NavDrawer.Fragments;
using NavDrawer.Helpers;

namespace NavDrawer.Activities
{
    [Activity(Label = "Home", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,Theme = "@style/MyTheme", Icon = "@drawable/ic_launcher")]
    public class HomeView : FragmentActivity
	{
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
        private string _drawerTitle;
        private string _title;
        private ListView _drawerList;
        private static readonly string[] Sections = new[]
            {
                "Browse", "Friends", "Profile"
            };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.page_home_view);

            this._title = this._drawerTitle = this.Title;
            this._drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this._drawerList = this.FindViewById<ListView>(Resource.Id.left_drawer);

            this._drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);

            //DrawerToggle is the animation that happens with the indicator next to the
            //ActionBar icon. You can choose not to use this.
            this._drawerToggle = new MyActionBarDrawerToggle(this, this._drawer,
                                                      Resource.Drawable.ic_drawer_light,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);

            //You can alternatively use _drawer.DrawerClosed here
            this._drawerToggle.DrawerClosed += delegate
            {
                this.ActionBar.Title = this._title;
                this.InvalidateOptionsMenu();
            };


            //You can alternatively use _drawer.DrawerOpened here
            this._drawerToggle.DrawerOpened += delegate
            {
                this.ActionBar.Title = this._drawerTitle;
                this.InvalidateOptionsMenu();
            };

            _drawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

            this._drawer.SetDrawerListener(this._drawerToggle);

            _drawerList.ItemClick += DrawerListOnItemClick;

            //if first time you will want to go ahead and click first item.
            if (null == savedInstanceState)
            {
                DrawerListOnItemClick(null, new AdapterView.ItemClickEventArgs(null, null, 0, 0));
            }
        }

        private void DrawerListOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (itemClickEventArgs.Position)
            {
                case 0:
                    fragment = new BrowseFragment();
                    break;
                case 1:
                    fragment = new FriendsFragment();
                    break;
                case 2:
                    fragment = new ProfileFragment();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();

            _drawerList.SetItemChecked(itemClickEventArgs.Position, true);
            ActionBar.Title = _title = Sections[itemClickEventArgs.Position];
            _drawer.CloseDrawer(_drawerList);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this._drawerToggle.SyncState();
        }


        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this._drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            var drawerOpen = this._drawer.IsDrawerOpen(this._drawerList);
            //when open down't show anything
            for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);


            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this._drawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }

	}
}

