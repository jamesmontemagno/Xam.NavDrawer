using Cirrious.MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace NavDrawer.Core.ViewModels
{
    public class MenuViewModel 
		: MvxViewModel
    {
        public ObservableCollection<MenuItem> MenuItems { get; private set; }

        public MenuViewModel ()
        {
            MenuItems = new ObservableCollection<MenuItem> ();

            MenuItems.Add (new MenuItem ("Browse"));
            MenuItems.Add (new MenuItem ("Friends"));
            MenuItems.Add (new MenuItem ("Profile"));
        }
        
    }
}
