using ScamMobileApp.Views;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Onboard;
using ScamMobileApp.Views.Questions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Inter-Regular.ttf", Alias = "Inter-Regular")]
[assembly: ExportFont("Inter-Light.ttf", Alias = "Inter-Light")]
[assembly: ExportFont("Inter-Medium.ttf", Alias = "Inter-Medium")]
[assembly: ExportFont("Inter-Bold.ttf", Alias = "Inter-Bold")]
[assembly: ExportFont("Inter-Black.ttf", Alias = "Inter-Black")]

namespace ScamMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Welcome2());

            //MainPage = new NavigationPage(new ProfilePage());

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
