using ScamMobileApp.ViewModels.More;
using ScamMobileApp.ViewModels.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = new NewsViewModel(Navigation);

        }

        #region Australia
        private async void Scamwatch(object sender, EventArgs e)
        {

            string url = "https://www.scamwatch.gov.au"; // Replace with your desired URL

            //await Launcher.OpenAsync(new Uri(url));

            await Launcher.OpenAsync(url);


            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void AustraliaCyber(object sender, EventArgs e)
        {

            string url = "https://www.cyber.gov.au/report-and-recover/report"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));


            //await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }

        private async void ACMA(object sender, EventArgs e)
        {

            string url = "https://www.acma.gov.au/spam-complaint-form"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));


            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion


    }
}