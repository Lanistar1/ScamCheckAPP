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
    public partial class FirstQuestion : ContentPage
    {
        public FirstQuestion()
        {
            InitializeComponent();
        }

        private void To_secondQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}