using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Employment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmploymentFirstQuestion : ContentPage
    {
        public EmploymentFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new EmploymentViewModel(Navigation);
        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmploymentSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}