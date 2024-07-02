using ScamMobileApp.Views;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Onboard;
using ScamMobileApp.Views.Questions;
using ScamMobileApp.Views.Questions.Impersonation;
using ScamMobileApp.Views.Questions.ZcamResultSuggestion;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Inter-Regular.ttf", Alias = "Inter-Regular")]
[assembly: ExportFont("Inter-Light.ttf", Alias = "Inter-Light")]
[assembly: ExportFont("Inter-Medium.ttf", Alias = "Inter-Medium")]
[assembly: ExportFont("Inter-Bold.ttf", Alias = "Inter-Bold")]
[assembly: ExportFont("Inter-Black.ttf", Alias = "Inter-Black")]
[assembly: ExportFont("AirbnbCereal-XBold.otf", Alias = "Airbnb-xBold")]
[assembly: ExportFont("AirbnbCereal-Medium.otf", Alias = "Airbnb-Medium")]
[assembly: ExportFont("AirbnbCereal-Light.otf", Alias = "Airbnb-Light")]
[assembly: ExportFont("AirbnbCereal-Bold.otf", Alias = "Airbnb-Bold")]
[assembly: ExportFont("AirbnbCereal-Black.otf", Alias = "Airbnb-Black")]

namespace ScamMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());

            //MainPage = new NavigationPage(new MoreMenu());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
