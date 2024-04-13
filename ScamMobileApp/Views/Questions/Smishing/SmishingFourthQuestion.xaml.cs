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
    public partial class SmishingFourthQuestion : ContentPage
    {
        public SmishingFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new SmishingViewModel(Navigation);

        }
        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}