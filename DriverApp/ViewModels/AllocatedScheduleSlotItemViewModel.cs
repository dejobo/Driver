using System;
using ColonyConcierge.APIData.Data.Logistics;
using ColonyConcierge.Mobile.Logistics.Localization.Resx;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
	public class AllocatedScheduleSlotItemViewModel : BindableObject
	{
		string TimeFormat = "hh:mm tt";
		
		public AllocatedScheduleSlot Model
		{
			get;
			set;
		}

		private bool mIsSchedule = false;
		public bool IsSchedule
		{
			get
			{
				return mIsSchedule;
			}
			set
			{
				OnPropertyChanging(nameof(IsSchedule));
				mIsSchedule = value;
				if (IsSchedule)
				{
					IsStandBy = false;
				}
				OnPropertyChanged(nameof(IsSchedule));
			}
		}

		//IsScheduleEnabled = Model.RemainingQuota > 0 || (IsSchedule)
		//can Standby = false
		private bool mIsScheduleEnabled = false;
		public bool IsScheduleEnabled
		{
			get
			{
				return mIsScheduleEnabled;
			}
			set
			{
				OnPropertyChanging(nameof(IsScheduleEnabled));
				mIsScheduleEnabled = value;
				OnPropertyChanged(nameof(IsScheduleEnabled));
				OnPropertyChanged(nameof(IsScheduleDisabled));
			}
		}

		public bool IsScheduleDisabled
		{
			get
			{
				return !mIsScheduleEnabled;
			}
		}

		private bool mIsStandBy = false;
		public bool IsStandBy
		{
			get
			{
				return mIsStandBy;
			}
			set
			{
				OnPropertyChanging(nameof(IsStandBy));
				mIsStandBy = value;
				if (IsStandBy)
				{
					IsSchedule = false;
				}
				OnPropertyChanged(nameof(IsStandBy));
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
				if (Model.EndTime != null)
				{
					var dateTime = TimeZoneInfo.ConvertTime(DateTime.Parse(Model.StartTime.Time), TimeZoneInfo.Local);
					var endTime = TimeZoneInfo.ConvertTime(DateTime.Parse(Model.EndTime.Time), TimeZoneInfo.Local);
					return dateTime.ToString(TimeFormat) + " - " + endTime.ToString(TimeFormat);
				}
				else 
				{
					var dateTime = TimeZoneInfo.ConvertTime(DateTime.Parse(Model.StartTime.Time), TimeZoneInfo.Local);
					return dateTime.ToString(TimeFormat);
				}
			}
		}

		public string RemainingQuotaDisplay 
		{
			get
			{
				if (Model == null)
				{
					return string.Empty;
				}
				if (Model.RemainingQuota > 0)
				{
					return "(" + Model.RemainingQuota + ")";
				}
				else 
				{
					return AppResources.StandBy;
				}
			}
		}

		public AllocatedScheduleSlotItemViewModel(AllocatedScheduleSlot allocatedScheduleSlot)
		{
			Model = allocatedScheduleSlot;
			var isSignedUp = Model.SignedUp.HasValue ? Model.SignedUp.Value : false;
			IsSchedule = isSignedUp ? (Model.SignupIsStandby.HasValue? !Model.SignupIsStandby.Value : false) : false;
			IsStandBy = isSignedUp ? (Model.SignupIsStandby.HasValue ? Model.SignupIsStandby.Value : false) : false;
			IsScheduleEnabled = Model.RemainingQuota > 0 || (IsSchedule);
		}
	}
}
