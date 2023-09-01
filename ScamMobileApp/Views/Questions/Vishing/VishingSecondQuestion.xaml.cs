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
    public partial class VishingSecondQuestion : ContentPage
    {
        public VishingSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new VishingViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VishingThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}