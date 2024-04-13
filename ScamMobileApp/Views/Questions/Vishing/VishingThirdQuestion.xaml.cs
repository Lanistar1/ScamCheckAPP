using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Vishing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VishingThirdQuestion : ContentPage
    {
        public VishingThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new VishingViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VishingFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}