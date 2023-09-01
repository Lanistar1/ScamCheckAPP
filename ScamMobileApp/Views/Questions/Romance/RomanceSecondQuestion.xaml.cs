using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Romance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RomanceSecondQuestion : ContentPage
    {
        public RomanceSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new RomanceViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RomanceThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}