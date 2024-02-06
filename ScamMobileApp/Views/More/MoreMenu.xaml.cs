using Rg.Plugins.Popup.Extensions;
using ScamMobileApp.Popup;
using ScamMobileApp.ViewModels.FeedBack;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
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
    public partial class MoreMenu : ContentPage
    {
        private string ScamQA { get; set; }

        public MoreMenu()
        {
            InitializeComponent();
            BindingContext = new OthersViewModel(Navigation);

        }

        private void To_Profile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private async void To_Terms(object sender, EventArgs e)
        {
            string url = "https://thescamalicious.com/terms"; // Replace with your desired URL

            await Navigation.PushAsync(new TermsWebview(url));

            //Navigation.PushAsync(new TermsAndConditions());
        }

        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new LogoutPopup());
        }

        private void To_HelpCenter(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpCenter());
        }

        private void To_ChangePassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }

        private void To_typeOFScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TypeOfScam());
        }

        private void To_ScamQA(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScamQA());
        }

        private void TowarningSign(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WarningSigns());
        }

        private void To_PreventiveTips(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreventiveTips());
        }

        private void To_ShareExperience(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShareExperience());
        }

        private void To_Scamlink(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScamLink());
        }
    }
}