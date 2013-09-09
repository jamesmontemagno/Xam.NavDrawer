using Android.App;
using Android.Support.V4.App;
using Android.Views;

using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Views;

using MvxSample.Core.ViewModels.Friends;

namespace MvxSample.Droid.Views
{
    [Activity(Label = "Friend", Theme = "@style/MyTheme", Icon = "@android:color/transparent", ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "MvxSample.Droid.Views.HomeView")]
    public class FriendView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            SetContentView(Resource.Layout.page_friend);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            var set = this.CreateBindingSet<FriendView, FriendViewModel>();
            set.Bind(ActionBar).For(v => v.Title).To(vm => vm.Title).Mode(MvxBindingMode.OneWay);
            set.Apply();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //Wrong:
                    //var intent = new Intent(this, typeof(HomeView));
                    //intent.AddFlags(ActivityFlags.ClearTop);
                    //StartActivity(intent);
                    NavUtils.NavigateUpFromSameTask(this);

                    //if this could be launched externally:
                    /*
                     var upIntent = NavUtils.GetParentActivityIntent(this);
                    if (NavUtils.ShouldUpRecreateTask(this, upIntent))
                    {
                        Android.Support.V4.App.TaskStackBuilder.Create(this).
                            AddNextIntentWithParentStack(upIntent).
                            StartActivities();
                    }
                    else
                    {
                        NavUtils.NavigateUpTo(this, upIntent);  
                    }
                     */
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}