using MvxSample.Core.ViewModels.Base;

namespace MvxSample.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel 
    {
        private HomeViewModel.Section m_Section;
        public HomeViewModel.Section Section
        {
            get { return this.m_Section; }
            set
            {
                this.m_Section = value;
                this.Id = (int)this.m_Section; this.RaisePropertyChanged(() => this.Section);
            }
        }
    }
}
