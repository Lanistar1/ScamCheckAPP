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
    public partial class SocialMedianThirdQuestion : ContentPage
    {
        public SocialMedianThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new SocialMediaViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SocialMediaFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}