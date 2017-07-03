using System;
using ColonyConcierge.APIData.Data.Logistics;
using Xamarin.Forms;
using System.Linq;
using ColonyConcierge.APIData.Data;

namespace ColonyConcierge.Mobile.Logistics
{
	public class ChildJobItemViewModel : BindableObject
	{		
		public JobDetails Model
		{
			get;
			set;
		}

		public ScheduledService ScheduledService
		{
			get;
			set;
		}

		public string Address
		{
			get
			{
				if (Model != null && Model.Addresses != null)
				{
					var address = Model.Addresses.FirstOrDefault(t => t.IsPreferred);
					if (address == null)
					{
						address = Model.Addresses.FirstOrDefault();
					}
					if (address != null)
					{
						return address.BasicAddress.ToAddressLine();
					}
				}
				return string.Empty;
			}
		}

		public string PhoneNumber
		{
			get
			{
				if (Model!= null && Model.PhoneNumbers != null)
				{
					var phone = Model.PhoneNumbers.OrderBy(t => t.Priority).FirstOrDefault();
					if (phone != null)
					{
						return phone.Number;
					}
				}
				return string.Empty;
			}
		}

		private Command mSendMessageCommand;
		public Command SendMessageCommand
		{
			get
			{
				return mSendMessageCommand = mSendMessageCommand ?? new Command(() =>
				 {
					 if (SendMessageCommandAction != null)
					 {
						 SendMessageCommandAction(this);
					 }
				 });
			}
		}
		public Action<ChildJobItemViewModel> SendMessageCommandAction
		{
			get; set;
		}

		private Command mDropoffCommand;
		public Command DropoffCommand
		{
			get
			{
				return mDropoffCommand = mDropoffCommand ?? new Command(() =>
				 {
					 if (DropoffCommandAction != null)
					 {
						 DropoffCommandAction(this);
					 }
				 });
			}
		}
		public Action<ChildJobItemViewModel> DropoffCommandAction
		{
			get; set;
		}


		public ChildJobItemViewModel(JobDetails job, ScheduledService scheduledService)
		{
			Model = job;
			ScheduledService = scheduledService;
		}
	}
}
