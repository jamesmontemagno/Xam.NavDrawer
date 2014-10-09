using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NavDrawer.Forms
{
	public class MenuPage : ContentPage
	{

		ObservableCollection<MenuItem> Items;
		private readonly MasterDetailPage master;
		private NavigationPage home;
		private NavigationPage friends;
		private NavigationPage profile;

		public MenuPage (MasterDetailPage masterDetail)
		{
			Items = new ObservableCollection<MenuItem> ();
			Items.Add (new MenuItem{ Title = "Home", Option = MenuOption.Home });
			Items.Add (new MenuItem{ Title = "Friends", Option = MenuOption.Friends });
			Items.Add (new MenuItem{ Title = "Profile", Option = MenuOption.Profile });
			master = masterDetail;

			Title = "menu";
			Icon = "ic_drawer_dark.png";
			BackgroundColor = Color.FromHex ("111111");

			var listView = new ListView {
				RowHeight = 60,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate (typeof(MenuCell)),
				ItemsSource = Items
			};

			listView.ItemSelected += (sender, e) => {

				var item = e.SelectedItem as MenuItem;
				if (item == null)
					return;

				Selected (item.Option);

				listView.SelectedItem = null;//clear out
			};

			Content = listView;
		}

		public void Selected (MenuOption item)
		{
			master.IsPresented = false; // close the slide-out

			switch (item) {
			case MenuOption.Home:
				master.Detail = home ??
					(home = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Home",
							Content = new Label { Text = "Home", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;
			case MenuOption.Friends:
				master.Detail = friends ??
					(friends = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Friends",
							Content = new Label { Text = "Friends", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;
			case MenuOption.Profile:
				master.Detail = profile ??
					(profile = new NavigationPage(
						new ContentPage 
						{ 
							Title = "Profile",
							Content = new Label { Text = "Profile", Font = Font.SystemFontOfSize (40), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center } 
						})
					);
				break;

			}
		}
	}
}

