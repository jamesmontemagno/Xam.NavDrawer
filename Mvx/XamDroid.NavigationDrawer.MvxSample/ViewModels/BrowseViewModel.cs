using System.Collections.Generic;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.Helpers;
using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;
using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Friends;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels
{
    public class BrowseViewModel : BaseViewModel 
    {

        public BrowseViewModel()
        {
            Items = Util.GenerateFriends();
            Items.Reverse();
        }

        private List<FriendViewModel> m_Items;
        public List<FriendViewModel> Items
        {
            get {return m_Items; }
            set { m_Items = value; RaisePropertyChanged(() => Items); }
        }

        private MvxCommand<FriendViewModel> m_GoToFriendCommand;

        public ICommand GoToFriendCommand
        {
            get { return m_GoToFriendCommand ?? (m_GoToFriendCommand = new MvxCommand<FriendViewModel>(ExecuteGoToFriendCommand)); }
        }

        private void ExecuteGoToFriendCommand(FriendViewModel friendViewModel)
        {
            this.ShowViewModel<FriendViewModel>(
                new { id = friendViewModel.Id, title = friendViewModel.Title, image = friendViewModel.Image });
        }
    }
}
