using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Investment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvestmentSecondQuestion : ContentPage
    {
        public InvestmentSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new InvestmentViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InvestmentThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}