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
    public partial class BusinesForthQuestion : ContentPage
    {
        public BusinesForthQuestion()
        {
            InitializeComponent();
            BindingContext = new BusinessViewModel(Navigation);

        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}