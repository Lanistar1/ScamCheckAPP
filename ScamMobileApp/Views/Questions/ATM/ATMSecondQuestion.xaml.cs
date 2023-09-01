using ScamMobileApp.ViewModels.ScamCalculator;
using ScamMobileApp.Views.Questions.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.ATM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ATMSecondQuestion : ContentPage
    {
        public ATMSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new ATMViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ATMThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}