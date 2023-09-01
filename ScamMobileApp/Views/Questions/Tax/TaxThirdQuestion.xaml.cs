using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Tax
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaxThirdQuestion : ContentPage
    {
        public TaxThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new TaxViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaxFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}