using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public partial class RestaurantMenuListView : ContentView
	{
		public ListView ListViewMenus
		{
			get
			{
				return this.ListView;
			}
		}

		public RestaurantMenuListView()
		{
			InitializeComponent();
		}
	}
}
