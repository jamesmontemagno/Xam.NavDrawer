using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NavDrawer.Activities;
using com.refractored.monodroidtoolkit.imageloader;
using Fragment = Android.Support.V4.App.Fragment;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using NavDrawer.Droid;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using NavDrawer.Core.ViewModels;
using Android.Runtime;

namespace NavDrawer.Fragments
{
    [Register("navdrawer.fragments.ProfileFragment")]
    public class ProfileFragment : MvxFragment<ProfileViewModel>
    {
        private ImageLoader m_ImageLoader;
        public ProfileFragment()
        {
            this.RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_profile, null);
            m_ImageLoader = new ImageLoader(Activity);
            view.FindViewById<TextView>(Resource.Id.profile_name).Text = "James Montemagno";
            view.FindViewById<TextView>(Resource.Id.profile_description).Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum.";
            m_ImageLoader.DisplayImage("https://lh6.googleusercontent.com/-cGOyhvv0Xb0/UQV41NcgFHI/AAAAAAAAKz4/MKYmmtSgajI/w140-h140-p/6b27f0ec682011e2bd9a22000a9f14ba_7.jpg", view.FindViewById<ImageView>(Resource.Id.profile_image), -1);

            /*view.FindViewById<ImageView>(Resource.Id.profile_image).Click += (sender, args) =>
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
                };*/
            return view;
        }

        /*var pendingIntent = Android.App.TaskStackBuilder.Create(Activity)
                                     .AddNextIntentWithParentStack(friendActivity)
                                     .GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);*/
    }
}