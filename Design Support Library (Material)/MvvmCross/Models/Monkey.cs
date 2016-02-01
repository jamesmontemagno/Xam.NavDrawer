using System.Collections.Generic;

using NavDrawer.Adapters;

namespace NavDrawer.Models
{
    public class Monkey
    {
        public void Init()
        {
            Items = Util.GenerateFriends();
            Items.RemoveRange(0, this.Items.Count - 2);
        }

        public string Image
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the unique ID for the menu
        /// </summary>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the menu
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        public string Details { get; set; }

       

        public List<Monkey> Items
        {
            get;
            set;
        }
    }
}