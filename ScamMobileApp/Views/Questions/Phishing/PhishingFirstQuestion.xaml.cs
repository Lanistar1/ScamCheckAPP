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
    public partial class PhishingFirstQuestion : ContentPage
    {
        public PhishingFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new PhishingViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PHishingSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}