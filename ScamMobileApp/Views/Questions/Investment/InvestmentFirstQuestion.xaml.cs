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
    public partial class InvestmentFirstQuestion : ContentPage
    {
        public InvestmentFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new InvestmentViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InvestmentSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}