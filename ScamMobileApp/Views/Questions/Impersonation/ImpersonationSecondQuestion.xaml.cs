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
    public partial class ImpersonationSecondQuestion : ContentPage
    {
        public ImpersonationSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new ImpersonationViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImpersonationThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}