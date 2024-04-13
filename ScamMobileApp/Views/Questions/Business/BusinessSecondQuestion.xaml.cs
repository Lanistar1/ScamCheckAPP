using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Business
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessSecondQuestion : ContentPage
    {
        public BusinessSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new BusinessViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BusinessThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}