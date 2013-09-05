using System;
using System.Collections.Generic;
using System.Linq;

using Android.Content;
using Android.Support.V4.App;

using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

namespace XamDroid.NavigationDrawer.MvxSample.Droid.Views.Adapters
{
    public class MvxViewPagerFragmentAdapter
      : FragmentPagerAdapter
    {
        public class FragmentInfo
        {
            public string Title { get; set; }
            public Type FragmentType { get; set; }
            public IMvxViewModel ViewModel { get; set; }
        }

        private readonly Context _context;

        public MvxViewPagerFragmentAdapter(
          Context context, FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
            : base(fragmentManager)
        {
            this._context = context;
            this.Fragments = fragments;
        }

        public IEnumerable<FragmentInfo> Fragments { get; private set; }

        public override int Count
        {
            get { return this.Fragments.Count(); }
        }

        public override Fragment GetItem(int position)
        {
            var frag = this.Fragments.ElementAt(position);
            var fragment = Fragment.Instantiate(this._context,
                                                this.FragmentJavaName(frag.FragmentType));
            ((MvxFragment)fragment).DataContext = frag.ViewModel;
            return fragment;
        }

        protected virtual string FragmentJavaName(Type fragmentType)
        {
            var namespaceText = fragmentType.Namespace ?? "";
            if (namespaceText.Length > 0)
                namespaceText = namespaceText.ToLowerInvariant() + ".";
            return namespaceText + fragmentType.Name;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) { return new Java.Lang.String(this.Fragments.ElementAt(p0).Title); }
    }
}