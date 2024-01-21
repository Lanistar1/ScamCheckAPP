using ScamMobileApp.Utils;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDashboard : ContentPage
    {
        public NewDashboard()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel(Navigation);

        }

        private void To_firstQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TypeOfScam());
        }

        private void To_ShareExperience(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShareScamExperience());
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

        private async void To_Profile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        //private async void To_AllFeedback(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AllFeedbackPage());
        //}

        private async void To_recentActivity(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllFeedbackPage());
        }
    }
}