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
    public partial class ImpersonationThirdQuestion : ContentPage
    {
        public ImpersonationThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new ImpersonationViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImpersonationFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}