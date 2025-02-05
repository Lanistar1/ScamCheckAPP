using Rg.Plugins.Popup.Extensions;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.ViewModels.FeedBack;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views.Questions;
using ScamMobileApp.Views.Questions.ZcamResultSuggestion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
                string msg = "Do you really want to exit this app?";
                await ConfirmPopup.Instance.Show(
                             title: "Message",
                             message: msg,
                             closeButtonText: "No",
                             acceptButtonText: "Yes",
                             acceptCommand: new Command(() =>
                             {
                                 System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow(); // Or anything else
                             }));
                //if (result)
                //{
                //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow(); // Or anything else
                //}
            });
            return true;
        }

        private void To_Profile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private async void To_Terms(object sender, EventArgs e)
        {
            //string url = "https://thescamalicious.com/terms"; // Replace with your desired URL

            //await Navigation.PushAsync(new TermsWebview(url));

            await Navigation.PushAsync(new TermsAndConditions());
        }


        private void Logout(object sender, EventArgs e)
        {
            //string url = "https://res.cloudinary.com/dj5o5rd0s/image/upload/v1711358540/sivaamalar_FINAL03_zmaww7.ai"; // Replace with your desired URL

            //await Navigation.PushAsync(new PdfWebViewPage(url));

            Navigation.PushPopupAsync(new LogoutPopup());
        }

        //private void Logout(object sender, EventArgs e)
        //{
            
        //    Navigation.PushAsync(new PdfWebViewPage());
        //}

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

        private void To_UnlikelyScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UnlikelyAScamSuggestion());

        }

        private void To_LikelyScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LikelyAScamSeggestion());

        }

        private void To_Scammed(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new Scammed());

        }

        private void To_Privacy(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PrivacyPolicy());
        }

        private void To_PostVisibility(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostVisibility());
        }

        private void To_NewsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewsPage());

        }

        private void To_AIImageCheck(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AIImageCheckPage());
        }

        private void To_TriviaQuestions(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TriviaQuestionPage());

        }
    }
}