using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.ViewModels;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        private long m_Id;
        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get { return m_Id; }
            set { m_Id = value; RaisePropertyChanged(() => Id); }
        }

        private string m_Title = string.Empty;
        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; RaisePropertyChanged(() => Title); }
        }
    }
}
