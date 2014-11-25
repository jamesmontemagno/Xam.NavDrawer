using MvxSample.Core.ViewModels.Base;

namespace MvxSample.Core.ViewModels.Friends
{
    public class FriendsViewModel : BaseViewModel
    {
        public FriendsViewModel()
        {
            FriendsAllViewModel = new FriendsAllViewModel();
            FriendsRecentViewModel = new FriendsRecentViewModel();
        }

        private FriendsAllViewModel m_FriendsAllViewModel;
        public FriendsAllViewModel FriendsAllViewModel
        {
            get { return this.m_FriendsAllViewModel; }
            set { this.m_FriendsAllViewModel = value; this.RaisePropertyChanged(() => this.FriendsAllViewModel); }
        }

        private FriendsRecentViewModel m_FriendsRecentViewModel;
        public FriendsRecentViewModel FriendsRecentViewModel
        {
            get { return this.m_FriendsRecentViewModel; }
            set { this.m_FriendsRecentViewModel = value; this.RaisePropertyChanged(() => this.FriendsRecentViewModel); }
        }
    }
}
