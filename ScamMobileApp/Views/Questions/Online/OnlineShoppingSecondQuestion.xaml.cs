using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Online
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnlineShoppingSecondQuestion : ContentPage
    {
        public OnlineShoppingSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new OnlineShoppingViewmodel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OnlineShoppingThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}