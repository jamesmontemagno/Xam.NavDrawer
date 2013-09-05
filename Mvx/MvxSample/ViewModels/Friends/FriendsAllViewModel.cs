using System.Collections.Generic;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

using MvxSample.Core.Helpers;
using MvxSample.Core.ViewModels.Base;

namespace MvxSample.Core.ViewModels.Friends
{
    public class FriendsAllViewModel : BaseViewModel
    {

        public FriendsAllViewModel()
        {
            this.Items = Util.GenerateFriends();
        }

        private List<FriendViewModel> m_Items;
        public List<FriendViewModel> Items
        {
            get {return this.m_Items; }
            set { this.m_Items = value; this.RaisePropertyChanged(() => this.Items); }
        }

        private MvxCommand<FriendViewModel> m_GoToFriendCommand;

        public ICommand GoToFriendCommand
        {
            get { return this.m_GoToFriendCommand ?? (this.m_GoToFriendCommand = new MvxCommand<FriendViewModel>(this.ExecuteGoToFriendCommand)); }
        }

        private void ExecuteGoToFriendCommand(FriendViewModel friendViewModel)
        {
            this.ShowViewModel<FriendViewModel>(
                new { id = friendViewModel.Id, title = friendViewModel.Title, image = friendViewModel.Image });
        }
    }
}
