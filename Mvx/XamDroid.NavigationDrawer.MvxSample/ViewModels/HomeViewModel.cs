using System;
using System.Collections.Generic;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;
using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Friends;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public enum Section
        {
            Unknown,
            Browse,
            Friends,
            Profile
        }

        public HomeViewModel()
        {
            m_MenuItems = new List<MenuViewModel>
                              {
                                  new MenuViewModel
                                      {
                                          Section = Section.Browse,
                                          Title = "Browse"
                                      },
                                  new MenuViewModel
                                      {
                                          Section = Section.Friends,
                                          Title = "Friends"
                                      },
                                  new MenuViewModel
                                      {
                                          Section = Section.Profile,
                                          Title = "Profile"
                                      },

                              };
        }

        private List<MenuViewModel> m_MenuItems;
        public List<MenuViewModel> MenuItems
        {
            get { return m_MenuItems; }
            set { m_MenuItems = value; RaisePropertyChanged(() => MenuItems); }
        }

        private MvxCommand<MenuViewModel> m_SelectMenuItemCommand;
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return m_SelectMenuItemCommand ?? (m_SelectMenuItemCommand = new MvxCommand<MenuViewModel>(ExecuteSelectMenuItemCommand));
            }
        }

        private void ExecuteSelectMenuItemCommand(MenuViewModel item)
        {
            //navigate if we have to, pass the id so we can grab from cache... or not
            switch (item.Section)
            {

                case Section.Browse:
                    ShowViewModel<BrowseViewModel>(new { item.Id });
                    break;
                case Section.Friends:
                    ShowViewModel<FriendsViewModel>(new { item.Id });
                    break;
                case Section.Profile:
                    ShowViewModel<ProfileViewModel>(new { item.Id });
                    break;
            }

        }

        public Section GetSectionForViewModelType(Type type)
        {

            if (type == typeof(BrowseViewModel))
                return Section.Browse;

            if (type == typeof(FriendsViewModel))
                return Section.Friends;

            if (type == typeof(ProfileViewModel))
                return Section.Profile;


            return Section.Unknown;
        }
    }
}
