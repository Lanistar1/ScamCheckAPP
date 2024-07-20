using ScamMobileApp.ViewModels.More;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HowToUseScamaliciousApp : ContentPage
	{
		public HowToUseScamaliciousApp ()
		{
			InitializeComponent ();
            BindingContext = new HelpCenterViewModel(Navigation);

        }
    }
}