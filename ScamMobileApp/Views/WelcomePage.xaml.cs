using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}

        private void To_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void To_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}