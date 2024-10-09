using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.More;
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
    public partial class HelpCenter : ContentPage
    {
        public HelpCenter()
        {
            InitializeComponent();
            BindingContext = new HelpCenterViewModel(Navigation);
        }

        private void To_HowToUseApp(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HowToUseScamaliciousApp());
        }

        private void To_ScamQA(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScamQA());

        }

        private void To_ContactUs(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactUsPage());
        }
    }
}