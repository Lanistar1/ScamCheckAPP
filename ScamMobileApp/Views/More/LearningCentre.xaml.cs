using ScamMobileApp.Views.Questions;
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
	public partial class LearningCentre : ContentPage
	{
		public LearningCentre ()
		{
			InitializeComponent ();
		}

        private void T0_ScamType(object sender, EventArgs e)
        {
			Navigation.PushAsync(new TypeOfScam());
        }

        private void To_PreventiveTips(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreventiveTips());
        }

        private void To_WarningSign(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WarningSigns());
        }
    }
}