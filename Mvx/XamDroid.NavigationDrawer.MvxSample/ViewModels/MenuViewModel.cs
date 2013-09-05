using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel 
    {
        private HomeViewModel.Section m_Section;
        public HomeViewModel.Section Section
        {
            get { return m_Section; }
            set
            {
                m_Section = value;
                Id = (int)m_Section; RaisePropertyChanged(() => Section);
            }
        }
    }
}
