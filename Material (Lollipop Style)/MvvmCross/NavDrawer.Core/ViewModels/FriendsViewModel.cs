using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using NavDrawer.Models;
using NavDrawer.Adapters;

namespace NavDrawer.Core.ViewModels
{
    public class FriendsViewModel 
		: MvxViewModel
    {
        public ObservableCollection<Friend> Friends { get; private set; }

        public FriendsViewModel ()
        {
            Friends = new ObservableCollection<Friend> (Util.GenerateFriends());

        }
        
    }
}
