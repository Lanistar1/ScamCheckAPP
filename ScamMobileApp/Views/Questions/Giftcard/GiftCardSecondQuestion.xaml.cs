using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Giftcard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GiftCardSecondQuestion : ContentPage
    {
        public GiftCardSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new GiftCardViewModel(Navigation);
        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GiftCardThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}