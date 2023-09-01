using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Romance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RomanceFirstQuestion : ContentPage
    {
        public RomanceFirstQuestion()
        {
            InitializeComponent();
            BindingContext = new RomanceViewModel(Navigation);

        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RomanceSecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}