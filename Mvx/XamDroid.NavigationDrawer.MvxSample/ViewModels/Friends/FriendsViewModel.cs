using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Friends
{
    public class FriendsViewModel : BaseViewModel
    {
        private FriendsAllViewModel m_FriendsAllViewModel;
        public FriendsAllViewModel FriendsAllViewModel
        {
            get { return m_FriendsAllViewModel; }
            set { m_FriendsAllViewModel = value; RaisePropertyChanged(() => FriendsAllViewModel); }
        }

        private FriendsRecentViewModel m_FriendsRecentViewModel;
        public FriendsRecentViewModel FriendsRecentViewModel
        {
            get { return m_FriendsRecentViewModel; }
            set { m_FriendsRecentViewModel = value; RaisePropertyChanged(() => FriendsRecentViewModel); }
        }
    }
}
