using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Models;
using UniversalImageLoader.Core;

namespace NavDrawer.Adapters
{
    internal class MonkeyAdapterWrapper : Java.Lang.Object
    {
        public TextView Title { get; set; }

        public ImageView Art { get; set; }
    }

    class MonkeyAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly IEnumerable<Monkey> friends;

        public ImageLoader ImageLoader { get; set; }

        public MonkeyAdapter(Activity context, IEnumerable<Monkey> friends)
        {
            this.context = context;
            this.friends = friends;
            ImageLoader = ImageLoader.Instance;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (position < 0)
                return null;

            var view = (convertView
                       ?? context.LayoutInflater.Inflate(
                           Resource.Layout.item_monkey, parent, false)
                       );

            if (view == null)
                return null;

            var wrapper = view.Tag as MonkeyAdapterWrapper;
            if (wrapper == null)
            {
                wrapper = new MonkeyAdapterWrapper
                {
                    Title = view.FindViewById<TextView>(Resource.Id.item_title),
                    Art = view.FindViewById<ImageView>(Resource.Id.item_image)
                };
                view.Tag = wrapper;
            }

            var friend = friends.ElementAt(position);

            wrapper.Title.Text = friend.Title;

            wrapper.Art.SetImageResource(Android.Resource.Color.Transparent);
            ImageLoader.DisplayImage(friend.Image, wrapper.Art);
            return view;
        }

        public override int Count
        {
            get { return friends.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }
    }
}