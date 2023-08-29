using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdQuestion : ContentPage
    {
        public ThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new ScamCalculatorViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}