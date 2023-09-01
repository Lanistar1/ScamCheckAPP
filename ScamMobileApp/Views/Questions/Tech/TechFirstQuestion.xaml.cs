using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Tech
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechFirstQuestion : ContentPage
    {
        public TechFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new TechSupportViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TechSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}