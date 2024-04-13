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
    public partial class SmishingFirstQuestion : ContentPage
    {
        public SmishingFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new SmishingViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SmishingSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}