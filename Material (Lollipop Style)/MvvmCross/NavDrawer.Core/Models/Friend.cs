using System.Collections.Generic;

using NavDrawer.Adapters;

namespace NavDrawer.Models
{
    public class Friend
    {
        private string m_Image;
        public string Image
        {
            get { return this.m_Image; }
            set { this.m_Image = value; }
        }


        private long m_Id;
        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }

        private string m_Title = string.Empty;
        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get { return this.m_Title; }
            set { this.m_Title = value; }
        }

        public void Init(int id, string title, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Image = image;
        }
    }
}