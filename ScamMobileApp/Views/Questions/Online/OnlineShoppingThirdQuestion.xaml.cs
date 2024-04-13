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
    public partial class OnlineShoppingThirdQuestion : ContentPage
    {
        public OnlineShoppingThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new OnlineShoppingViewmodel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OnlineShoppingFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}