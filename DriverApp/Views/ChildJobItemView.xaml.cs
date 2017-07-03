using System;
using System.Collections.Generic;
using ColonyConcierge.APIData.Data;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public partial class ChildJobItemView : ContentView
	{
		public bool IsShowButton
		{
			get
			{
				return GridButton.IsVisible;
			}
			set
			{
				GridButton.IsVisible = value;
			}
		}

		public bool IsCanDropOff
		{
			get
			{
				return ButtonDropOff.IsEnabled;
			}
			set
			{
				ButtonDropOff.IsEnabled = value;
			}
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			StackLayoutOrderDetails.Children.Clear();
			if (this.BindingContext is ChildJobItemViewModel)
			{
				var childJobItemViewModel = this.BindingContext as ChildJobItemViewModel;
				if (childJobItemViewModel.ScheduledService is ScheduledRestaurantService)
				{
					var scheduledRestaurantService = childJobItemViewModel.ScheduledService as ScheduledRestaurantService;
					if (!string.IsNullOrEmpty(scheduledRestaurantService.SpecialInstructions))
					{
						LabelSpecialInstructions.Text = "Order notes: " + scheduledRestaurantService.SpecialInstructions;
					}
					if (scheduledRestaurantService.Items != null)
					{
						foreach (var scheduledRestaurantServiceItem in scheduledRestaurantService.Items)
						{
							var cartItemView = new CartItemView();
							cartItemView.BindingContext = scheduledRestaurantServiceItem;
							cartItemView.Margin = new Thickness(0, 0, 0, 12);
							StackLayoutOrderDetails.Children.Add(cartItemView);
						}
					}
				}
			}
		}

		public ChildJobItemView()
		{
			InitializeComponent();

			GridPhone.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => 
				{
					if (!string.IsNullOrEmpty(LabelPhone.Text))
					{
						Utils.CallPhone(LabelPhone.Text);
					}
				})
			});


			GridAddress.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() =>
				{
					if (!string.IsNullOrEmpty(LabelAddress.Text))
					{
						Utils.OpenMap(LabelAddress.Text);
					}
				})
			});

			GridOrderDetailsTitle.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = new Command(() => 
				{
					StackLayoutOrderDetails.IsVisible = !StackLayoutOrderDetails.IsVisible;
					LabelSpecialInstructions.IsVisible = StackLayoutOrderDetails.IsVisible && !string.IsNullOrEmpty(LabelSpecialInstructions.Text);
					ImageOrderDetailsTitle.Source = StackLayoutOrderDetails.IsVisible ? "Less.png" : "Add.png";
				}),
			});
		}
	}
}
