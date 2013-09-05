using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.Helpers;
using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Friends
{
    public class FriendViewModel : BaseViewModel
    {
        private string m_Image;
        public string Image
        {
            get {return m_Image; }
            set { m_Image = value; RaisePropertyChanged(() => Image); }
        }

        public void Init(int id, string title, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Image = image;
            Items = Util.GenerateFriends();
            Items.RemoveRange(0, Items.Count - 2);
        }

        private List<FriendViewModel> m_Items;
        public List<FriendViewModel> Items
        {
            get { return m_Items; }
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
