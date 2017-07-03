using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public partial class ActivityIndicatorView : ContentView
	{
		public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(ActivityIndicatorView), default(bool), BindingMode.OneWay, null, (bindable, oldValue, newValue) =>
	   {
		   if (bindable is ActivityIndicatorView)
		   {
			   var activityIndicatorView = bindable as ActivityIndicatorView;
			   Device.BeginInvokeOnMainThread(() =>
			   {
				   activityIndicatorView.ActivityIndicatorControl.IsRunning = Convert.ToBoolean(newValue);
			   });
		   }
	   });

		public bool IsRunning
		{
			get
			{
				return (bool)GetValue(IsRunningProperty);
			}
			set
			{
				SetValue(IsRunningProperty, value);
			}
		}

		public ActivityIndicatorView()
		{
			InitializeComponent();
			this.PropertyChanged += (sender, e) =>
			{
			};

			this.SizeChanged += (sender, e) =>
			{
				if (this.Width > 1 && ActivityIndicatorControl.Width > 1)
				{
					var ratio = Device.Android == Device.RuntimePlatform ? 8 : 9;
					GridIndicatorControl.Scale = Math.Max(1, Math.Max(this.Width / ratio, 28) / ActivityIndicatorControl.Width);
					GridIndicatorControl.Margin = new Thickness(0, 0, 0, this.Height / 10);
				}
			};

			ActivityIndicatorControl.SizeChanged += (sender, e) =>
			{
				if (this.Width > 1 && ActivityIndicatorControl.Width > 1)
				{
					var ratio = Device.Android == Device.RuntimePlatform ? 8 : 9;
					GridIndicatorControl.Scale = Math.Max(1, Math.Max(this.Width / ratio, 28) / ActivityIndicatorControl.Width);
				}
			};

			if (Device.Android == Device.RuntimePlatform)
			{
				GridIndicatorControl.HasShadow = true;
			}
		}
	}
}
