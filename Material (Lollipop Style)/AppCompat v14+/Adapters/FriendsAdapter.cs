

using Android.Support.V4.App;

using NavDrawer.Fragments;

namespace NavDrawer.Adapters
{
    class FriendsAdapter: FragmentPagerAdapter
    {
        private static readonly string[] Content = new[]
            {
                "All", "Recent"
            };

        public FriendsAdapter(FragmentManager p0) 
                : base(p0) 
            { }

            public override int Count
            {
                get { return Content.Length; }
            }

            public override Fragment GetItem(int index)
            {
                switch (index)
                {
                    case 0:
                        return new FriendsAllFragment();
                    case 1:
                        return new FriendsRecentFragment();
                }

                return null;
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) { return new Java.Lang.String(Content[p0 % Content.Length].ToUpper()); }
    }
}