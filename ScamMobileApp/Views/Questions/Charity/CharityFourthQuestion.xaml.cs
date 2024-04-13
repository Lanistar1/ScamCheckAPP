using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Charity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharityFourthQuestion : ContentPage
    {
        public CharityFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new CharityViewModel(Navigation);

        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}