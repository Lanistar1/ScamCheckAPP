using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Phishing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhishingThirdQuestion : ContentPage
    {
        public PhishingThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new PhishingViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PhishingFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}