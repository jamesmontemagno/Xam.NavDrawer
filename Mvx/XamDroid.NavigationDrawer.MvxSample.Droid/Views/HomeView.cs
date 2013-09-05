using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;

using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels;
using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Friends;
using XamDroid.NavigationDrawer.MvxSample.Droid.Helpers;
using XamDroid.NavigationDrawer.MvxSample.Droid.Views.Fragments;

namespace XamDroid.NavigationDrawer.MvxSample.Droid.Views
{
    [Activity(Label = "Home", Theme = "@style/MyTheme", Icon = "@drawable/Icon")]
    public class HomeView : MvxFragmentActivity, IFragmentHost
	{
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
        private string _drawerTitle;
        private string _title;
        private MvxListView _drawerList;

		private HomeViewModel m_ViewModel;
		public new HomeViewModel ViewModel
		{
			get { return this.m_ViewModel ?? (this.m_ViewModel = base.ViewModel as HomeViewModel); }
		}


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.page_home_view);

            this._title = this._drawerTitle = this.Title;
            this._drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this._drawerList = this.FindViewById<MvxListView>(Resource.Id.left_drawer);

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

            this._drawer.SetDrawerListener(this._drawerToggle);


            this.RegisterForDetailsRequests();

            if (null == savedInstanceState)
            {
                this.ViewModel.SelectMenuItemCommand.Execute(this.ViewModel.MenuItems[0]);
            }
        }

        /// <summary>
        /// Use the custom presenter to determine if we can navigate forward.
        /// </summary>
        private void RegisterForDetailsRequests()
        {
            var customPresenter = Mvx.Resolve<ICustomPresenter>();
            customPresenter.Register(typeof(FriendsViewModel), this);
            customPresenter.Register(typeof(BrowseViewModel), this);
            customPresenter.Register(typeof(ProfileViewModel), this);

        }

        /// <summary>
        /// Read all about this, but this is a nice way if there were multiple
        /// fragments on the screen for us to decide what and where to show stuff
        /// See: http://enginecore.blogspot.ro/2013/06/more-dynamic-android-fragments-with.html
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool Show(MvxViewModelRequest request)
        {
            try
            {
                MvxFragment frag = null;
                var title = string.Empty;
                var section = this.ViewModel.GetSectionForViewModelType(request.ViewModelType);

                switch (section)
                {
                    case HomeViewModel.Section.Browse:
                        {
                            if (this.SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as BrowseView != null)
                            {
                                return true;
                            }

                            frag = new BrowseView();
                            title = "Browse";
                        }
                        break;
                    case HomeViewModel.Section.Friends:
                        {
                            if (this.SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as FriendsView != null)
                            {
                                return true;
                            }

                            frag = new FriendsView();
                            title = "Friends";
                        }
                        break;
                    case HomeViewModel.Section.Profile:
                        {
                            if (this.SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as ProfileView != null)
                            {
                                return true;
                            }

                            frag = new ProfileView();
                            title = "Profile";
                        }
                }

                var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
                var viewModel = loaderService.LoadViewModel(request, null /* saved state */);

                frag.ViewModel = viewModel;

                // TODO - replace this with extension method when available

                //Normally we would do this, but we already have it
                this.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, frag).Commit();
                this._drawerList.SetItemChecked(this.ViewModel.MenuItems.FindIndex(m=>m.Id == (int)section), true);
                this.ActionBar.Title = this._title = title;

                this._drawer.CloseDrawer(this._drawerList);

                return true;
            }
            finally
            {
                this._drawer.CloseDrawer(this._drawerList); 
            }
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

