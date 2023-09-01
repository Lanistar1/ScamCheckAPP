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
    public partial class SocialMediaFirstQuestion : ContentPage
    {
        public SocialMediaFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new SocialMediaViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SocialMediaSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}