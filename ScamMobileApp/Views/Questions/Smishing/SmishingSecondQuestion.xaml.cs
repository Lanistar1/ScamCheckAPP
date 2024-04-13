using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Smishing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmishingSecondQuestion : ContentPage
    {
        public SmishingSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new SmishingViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SmishingThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}