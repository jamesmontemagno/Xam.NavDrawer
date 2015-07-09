using Cirrious.MvvmCross.ViewModels;

namespace NavDrawer.Core.ViewModels
{
    public class HomeViewModel 
		: MvxViewModel
    {
        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel> ();
        }
    }
}
