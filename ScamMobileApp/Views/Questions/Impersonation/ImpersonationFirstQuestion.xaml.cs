using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Impersonation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImpersonationFirstQuestion : ContentPage
    {
        public ImpersonationFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new ImpersonationViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImpersonationSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}