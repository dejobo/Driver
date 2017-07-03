using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics.ViewModels
{
    public class MasterPageItemViewModel : BindableObject
    {
		private string mTitle = string.Empty;
		public string Title
		{
			get
			{
				return mTitle;
			}
			set
			{
				OnPropertyChanging(nameof(Title));
				mTitle = value;
				OnPropertyChanged(nameof(Title));
			}
		}

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
		public object Parameter { get; set; }
		public string Name { get; internal set; }
	}
}
