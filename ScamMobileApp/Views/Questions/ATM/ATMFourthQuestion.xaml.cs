using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.ATM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ATMFourthQuestion : ContentPage
    {
        public ATMFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new ATMViewModel(Navigation);

        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}