using System;

using Xamarin.Forms.Platform.Android;
using Android.Content.PM;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Android.App;
using Android.OS;

namespace NavDrawer.Forms
{
	[Activity (Label = "NavDrawer.Forms", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, Theme = "@android:style/Theme.Holo.Light.DarkActionBar")]
	public class MainActivity : AndroidActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);
			SetPage (App.GetPage());
		}
	}


	public static class App
	{
		public static Page GetPage ()
		{
			var masterDetail = new MasterDetailPage ();
			var master = new MenuPage (masterDetail);

			masterDetail.Master = master;
			master.Selected (MenuOption.Home);
			return masterDetail;
		}
	}



}
	


