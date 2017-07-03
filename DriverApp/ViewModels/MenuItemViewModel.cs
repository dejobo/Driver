using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public class MenuItemViewModel : BindableObject
	{
		private List<MenuGroupModifierItem> mListMenuGroupModifierItemSelected = new List<MenuGroupModifierItem>();
		public List<MenuGroupModifierItem> ListMenuGroupModifierItemSelected
		{
			get
			{
				return mListMenuGroupModifierItemSelected;
			}
		}

		public bool IsMenuSection
		{
			get
			{
				return RestaurantMenuItem == null;
			}
		}
		public bool IsMenuItem 
		{
			get
			{
				return RestaurantMenuItem != null;
			}
		}

		private bool mIsEnabled = true;
		public bool IsEnabled
		{
			get
			{
				return mIsEnabled;
			}
			set
			{
				OnPropertyChanging(nameof(IsEnabled));
				mIsEnabled = value;
				OnPropertyChanged(nameof(IsEnabled));
			}
		}

		private bool mIsSelected = false;
		public bool IsSelected
		{
			get
			{
				return mIsSelected;
			}
			set
			{
				OnPropertyChanging(nameof(IsSelected));
				mIsSelected = value;
				OnPropertyChanged(nameof(IsSelected));
			}
		}

		public string SectionName 
		{
			get;
			set;
		}

		public string SectionDetail
		{
			get;
			set;
		}

		public RestaurantMenuItemViewModel RestaurantMenuItem 
		{ 
			get; 
			set; 
		}

		public MenuItemViewModel()
		{
		}
	}

	public class MenuGroupModifierItem : BindableObject
	{
		public MenuItemViewModel MenuItemView { get; set; }
		public int Quantity { get; set; } = 1;
		public List<RMenuGroupModifierVM> ListRMenuGroupModifierVM { get; set; } = new List<RMenuGroupModifierVM>();
		public string Comment { get; set; }

		private decimal mPrice = 0;
		public decimal Price
		{
			get
			{
				return mPrice;
			}
		}

		public string DisplayPrice
		{
			get
			{
				if (Price > 0) return "$" + Price;
				return string.Empty;
			}
		}

		public void UpdatePrice()
		{
			var price = RestaurantMenuItemModifierPage.UpdatePrice(MenuItemView.RestaurantMenuItem.MenuItemVM, ListRMenuGroupModifierVM, this.Quantity);
			if (price.HasValue)
			{
				mPrice = price.Value;
			}
			else
			{
				mPrice = 0;
			}
			OnPropertyChanged(nameof(Price));
			OnPropertyChanged(nameof(DisplayPrice));
		}

		public void RaiseAllOnChanged()
		{
			OnPropertyChanged(nameof(MenuItemView));
			OnPropertyChanged(nameof(ListRMenuGroupModifierVM));
			OnPropertyChanged(nameof(Quantity));
			OnPropertyChanged(nameof(Comment));
			OnPropertyChanged(nameof(Price));
			OnPropertyChanged(nameof(DisplayPrice));
		}

		public MenuGroupModifierItem(MenuItemViewModel menuItemView, List<RMenuGroupModifierVM> listRMenuGroupModifierVM, int quantity, string comment ="")
		{
			MenuItemView = menuItemView;
			ListRMenuGroupModifierVM = listRMenuGroupModifierVM;
			Quantity = quantity;
			Comment = comment;
		}
	}
}
