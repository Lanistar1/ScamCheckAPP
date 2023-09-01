using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Grandparent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrandParentThirdQuestion : ContentPage
    {
        public GrandParentThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new GrandParentViewModel(Navigation);
        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GrandParentFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}