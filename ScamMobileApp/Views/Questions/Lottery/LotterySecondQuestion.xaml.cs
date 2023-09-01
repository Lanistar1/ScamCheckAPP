using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Lottery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotterySecondQuestion : ContentPage
    {
        public LotterySecondQuestion()
        {
            InitializeComponent();
            BindingContext = new LotteryViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LotteryThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}