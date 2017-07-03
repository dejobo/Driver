using System;
using ColonyConcierge.APIData.Data.Logistics;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public class JobItemViewModel : BindableObject
	{
		string TimeFormat = "h:mm tt";
		
		public Job Model
		{
			get;
			set;
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

		private bool mIsClaimEnabled = true;
		public bool IsClaimEnabled
		{
			get
			{
				return mIsClaimEnabled;
			}
			set
			{
				OnPropertyChanging(nameof(IsClaimEnabled));
				mIsClaimEnabled = value;
                OnPropertyChanged(nameof(ClaimCommand));
                OnPropertyChanged(nameof(IsClaimEnabled));
			}
		}

		public string DisplayTime
		{
			get
			{
				if (Model == null)
				{
					return string.Empty;
				}
				var dateTime = TimeZoneInfo.ConvertTime(DateTime.Parse(Model.Time.ToString()), TimeZoneInfo.Local);
				return dateTime.ToString(TimeFormat);
			}
		}

		private Command mClaimCommand;
		public Command ClaimCommand
		{
			get
			{
				if (mIsClaimEnabled)
				{
					return mClaimCommand = mClaimCommand ?? new Command(() =>
					 {
						 if (ClaimCommandAction != null)
						 {
							 ClaimCommandAction(this);
						 }
					 });
				}
				else
				{
					return null;
				}
			}
		}
		public Action<JobItemViewModel> ClaimCommandAction
		{
			get; set;
		}


		public JobItemViewModel(Job job)
		{
			Model = job;
		}
	}
}
