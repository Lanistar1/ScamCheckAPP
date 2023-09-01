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
    public partial class PhishingFourthQuestion : ContentPage
    {
        public PhishingFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new PhishingViewModel(Navigation);

        }
        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}