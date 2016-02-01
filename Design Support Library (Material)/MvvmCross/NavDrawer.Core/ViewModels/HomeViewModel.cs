using System;
using MvvmCross.Core.ViewModels;

namespace NavDrawer.Core.ViewModels
{
	public class HomeViewModel : MvxViewModel
	{
		public HomeViewModel ()
		{
		}

		public void ShowBrowse()
		{
			ShowViewModel<BrowseViewModel> ();
		}

		public void ShowFriends()
		{
			ShowViewModel<FriendsViewModel> ();
		}

		public void ShowProfile()
		{
			ShowViewModel<ProfileViewModel> ();
		}
	}
}

