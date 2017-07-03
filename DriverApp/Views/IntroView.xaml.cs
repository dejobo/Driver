using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ColonyConcierge.Mobile.Logistics
{
    public partial class IntroView : ContentView
    {
        public IntroView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
			Application.Current.MainPage = new NavigationPage(new SigninPage()); 
		}
    }
}
