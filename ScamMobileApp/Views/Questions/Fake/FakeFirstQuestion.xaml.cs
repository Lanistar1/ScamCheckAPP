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
    public partial class FakeFirstQuestion : ContentPage
    {
        public FakeFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new FakeInvoiceViewModel(Navigation);
        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FakeSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}