using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace NavDrawer.Core.ViewModels
{
    public class MenuViewModel 
		: MvxViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; private set; }

        private MvxCommand<MenuItem> itemSelectedCommand;

        public IMvxCommand ItemSelectedCommand
        {
            get
            {
                itemSelectedCommand = itemSelectedCommand ?? new MvxCommand<MenuItem>(MenuAction);
                return itemSelectedCommand;
            }
        }

        public void MenuAction(MenuItem item)
        {
            ShowViewModel (item.ViewModelType);
        }

        public MenuViewModel ()
        {
            MenuItems = new ObservableCollection<MenuItem> ();

            MenuItems.Add (new MenuItem (){Title = "Browse", ViewModelType = typeof(BrowseViewModel)});
            MenuItems.Add (new MenuItem (){Title = "Friends", ViewModelType = typeof(FriendsViewModel)});
            MenuItems.Add (new MenuItem (){ Title = "Profile", ViewModelType = typeof(ProfileViewModel)});
        }
    }
}
