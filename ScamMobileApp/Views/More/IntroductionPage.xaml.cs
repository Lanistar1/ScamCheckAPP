using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels.More;
using ScamMobileApp.ViewModels.Others;
using ScamMobileApp.Views.AIScam;
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
	public partial class IntroductionPage : ContentPage
	{
        public IntroductionPage ()
		{
            InitializeComponent();
            BindingContext = new LearningCentreViewModel(Navigation);

        }

        private void To_AIDrivenScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AIDrivenScam());
        }

        private void To_SpotAIScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SpotAIScam());

        }

        private void To_StayAhead(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StayAheadOfAIScam());

        }
    }
}