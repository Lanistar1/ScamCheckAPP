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
    public partial class LotteryFirstQuestion : ContentPage
    {
        public LotteryFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new LotteryViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LotterySecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}