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
    public partial class FakeSecondQuestion : ContentPage
    {
        public FakeSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new FakeInvoiceViewModel(Navigation);
        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FakeThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}