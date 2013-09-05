using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.MvvmCross.ViewModels;

using XamDroid.NavigationDrawer.MvxSample.Core.ViewModels.Base;

namespace XamDroid.NavigationDrawer.MvxSample.Core.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {

        public ProfileViewModel()
        {
            Title = "James Montemagno";
            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.";
            Image = "https://lh6.googleusercontent.com/-cGOyhvv0Xb0/UQV41NcgFHI/AAAAAAAAKz4/MKYmmtSgajI/w140-h140-p/6b27f0ec682011e2bd9a22000a9f14ba_7.jpg";
        }

        private string m_Image;
        public string Image
        {
            get { return m_Image; }
            set { m_Image = value; RaisePropertyChanged(() => Image); }
        }

        private string m_Description;
        public string Description
        {
            get {return m_Description; }
            set { m_Description = value; RaisePropertyChanged(() => Description); }
        }
    }
}
