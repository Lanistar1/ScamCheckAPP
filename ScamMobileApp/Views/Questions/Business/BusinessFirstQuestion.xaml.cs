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
    public partial class BusinessFirstQuestion : ContentPage
    {
        public BusinessFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new BusinessViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BusinessSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}