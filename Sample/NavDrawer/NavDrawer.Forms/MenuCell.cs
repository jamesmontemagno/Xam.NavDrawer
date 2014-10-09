using System;
using Xamarin.Forms;

namespace NavDrawer.Forms
{
	public enum MenuOption
	{
		Home,
		Friends,
		Profile
	}
	public class MenuItem
	{
		public string Title {get;set;}
		public MenuOption Option { get; set;}
	}

	public class MenuCell : ViewCell
	{
		readonly Label _label;

		public MenuCell()
		{
			_label = new Label
			{
				VerticalOptions = LayoutOptions.Center,
				TextColor = Color.White,
				Font = Device.OnPlatform(Font.OfSize("HelveticaNeue-Thin", 30),
					Font.SystemFontOfSize(25),
					Font.SystemFontOfSize(40))
			};


			_label.SetBinding (Label.TextProperty, "Title");

			var layout = new StackLayout
			{
				Padding = new Thickness(25, 5, 10, 5),
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {  _label }
			};
					
			View = layout;
		}
	}
}

