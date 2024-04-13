using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Ransomware
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RansomwareThirdQuestion : ContentPage
    {
        public RansomwareThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new RansomewareViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RansomwareFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}