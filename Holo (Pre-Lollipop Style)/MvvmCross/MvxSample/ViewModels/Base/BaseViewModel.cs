using Cirrious.MvvmCross.ViewModels;

namespace MvxSample.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        private long m_Id;
        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; this.RaisePropertyChanged(() => this.Id); }
        }

        private string m_Title = string.Empty;
        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get { return this.m_Title; }
            set { this.m_Title = value; this.RaisePropertyChanged(() => this.Title); }
        }
    }
}
