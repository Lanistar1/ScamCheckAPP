using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Fake
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FakeThirdQuestion : ContentPage
    {
        public FakeThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new FakeInvoiceViewModel(Navigation);
        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FakeFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}