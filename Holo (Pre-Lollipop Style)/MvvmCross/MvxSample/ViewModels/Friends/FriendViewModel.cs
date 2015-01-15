using System.Collections.Generic;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

using MvxSample.Core.Helpers;
using MvxSample.Core.ViewModels.Base;

namespace MvxSample.Core.ViewModels.Friends
{
    public class FriendViewModel : BaseViewModel
    {
        private string m_Image;
        public string Image
        {
            get {return this.m_Image; }
            set { this.m_Image = value; this.RaisePropertyChanged(() => this.Image); }
        }

        public void Init(int id, string title, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Image = image;
            this.Items = Util.GenerateFriends();
            this.Items.RemoveRange(0, this.Items.Count - 2);
        }

        private List<FriendViewModel> m_Items;
        public List<FriendViewModel> Items
        {
            get { return this.m_Items; }
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
