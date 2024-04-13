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
    public partial class GiftCardThirdQuestion : ContentPage
    {
        public GiftCardThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new GiftCardViewModel(Navigation);
        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GiftCardFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}