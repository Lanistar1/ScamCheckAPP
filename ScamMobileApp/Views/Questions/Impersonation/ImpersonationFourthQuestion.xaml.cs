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
    public partial class ImpersonationFourthQuestion : ContentPage
    {
        public ImpersonationFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new ImpersonationViewModel(Navigation);

        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}