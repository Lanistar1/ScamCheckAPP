using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondQuestion : ContentPage
    {
        public SecondQuestion()
        {
            InitializeComponent();
        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}