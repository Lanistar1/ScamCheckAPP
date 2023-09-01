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
    public partial class GiftCardFourthQuestion : ContentPage
    {
        public GiftCardFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new GiftCardViewModel(Navigation);
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}