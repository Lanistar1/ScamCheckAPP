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
    public partial class IdentitySecondQuestion : ContentPage
    {
        public IdentitySecondQuestion()
        {
            InitializeComponent();
            BindingContext = new IdentityTheftViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IdentityThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}