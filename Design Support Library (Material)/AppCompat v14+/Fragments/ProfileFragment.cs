using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Activities;
using Fragment = Android.Support.V4.App.Fragment;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using UniversalImageLoader.Core;

namespace NavDrawer.Fragments
{
    public class ProfileFragment : Fragment
    {
		private ImageLoader imageLoader;
        public ProfileFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_profile, null);
            imageLoader = ImageLoader.Instance;
            view.FindViewById<TextView>(Resource.Id.profile_name).Text = "James Montemagno";
			view.FindViewById<TextView>(Resource.Id.profile_description).Text = "James Montemagno is a Developer Evangelist at Xamarin and Microsoft MVP. He has been a .NET developer for over a decade working in a wide range of industries and before joining Xamarin was a professional mobile developer on the Xamarin platform for over 4 years. He can be found on Twitter @JamesMontemagno and blogs regularly at  www.MotzCod.es";
            imageLoader.DisplayImage("https://s.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca?s=250", view.FindViewById<ImageView>(Resource.Id.profile_image));

            view.FindViewById<ImageView>(Resource.Id.profile_image).Click += (sender, args) =>
                {
                    var builder = new NotificationCompat.Builder(Activity)
                    .SetSmallIcon(Resource.Drawable.ic_launcher)
                    .SetContentTitle("Click to go to friend details!")
                    .SetContentText("New Friend!!");
                            
                    var friendActivity = new Intent(Activity, typeof(FriendActivity));

                    PendingIntent pendingIntent = PendingIntent.GetActivity(Activity, 0, friendActivity, 0);
                  

                    builder.SetContentIntent(pendingIntent);
                    builder.SetAutoCancel(true);
                    var notificationManager = 
                        (NotificationManager) Activity.GetSystemService(Context.NotificationService);
                    notificationManager.Notify(0, builder.Build());
                };
            return view;
        }

        /*var pendingIntent = Android.App.TaskStackBuilder.Create(Activity)
                                     .AddNextIntentWithParentStack(friendActivity)
                                     .GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);*/
    }
}