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
    public partial class GiftCardFirstQuestion : ContentPage
    {
        public GiftCardFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new GiftCardViewModel(Navigation);
        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GiftCardSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}