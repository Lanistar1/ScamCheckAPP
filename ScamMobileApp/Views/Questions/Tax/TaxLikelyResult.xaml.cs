using Rg.Plugins.Popup.Extensions;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.ViewModels.ScamCalculator;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Tax
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaxLikelyResult : ContentPage
    {
        public TaxLikelyResult()
        {
            InitializeComponent();
            BindingContext = new TaxViewModel(Navigation);

        }

        private void To_Dashboard(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tabbed());
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

        private void To_FeedbackPopup(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new FeedbackPopup());

            taxlikely.IsVisible = false;

        }

        private void To_AntiScam(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShareScamExperience());
        }

        private void To_ScamLink(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScamLink());
        }
    }
}