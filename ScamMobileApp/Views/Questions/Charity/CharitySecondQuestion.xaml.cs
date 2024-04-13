using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Charity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharitySecondQuestion : ContentPage
    {
        public CharitySecondQuestion()
        {
            InitializeComponent();
            BindingContext = new CharityViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CharityThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}