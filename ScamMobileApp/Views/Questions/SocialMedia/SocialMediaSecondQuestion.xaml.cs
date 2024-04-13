using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.SocialMedia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialMediaSecondQuestion : ContentPage
    {
        public SocialMediaSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new SocialMediaViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SocialMedianThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}