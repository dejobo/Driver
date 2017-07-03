using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonyConcierge.Mobile.Logistics.ViewModels
{
    public class IntroViewModel
    {
        public IntroViewModel()
        {
            System.Diagnostics.Debug.WriteLine("creating intro");
        }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Boolean ShowLogin { get; set; }
    }
}
