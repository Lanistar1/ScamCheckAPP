using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdentityThirdQuestion : ContentPage
    {
        public IdentityThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new IdentityTheftViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IdentityFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}