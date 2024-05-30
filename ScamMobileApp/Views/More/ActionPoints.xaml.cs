using ScamMobileApp.Views.Questions.ZcamResultSuggestion;
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
	public partial class ActionPoints : ContentPage
	{
		public ActionPoints ()
		{
			InitializeComponent ();
		}

        private void To_LikelyAScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LikelyAScamSeggestion());
        }

        private void To_UnlikelyAScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UnlikelyAScamSuggestion());
        }

        private void To_Scammed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Scammed());
        }
    }
}