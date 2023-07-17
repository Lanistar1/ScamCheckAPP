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
    public partial class ForthQuestion : ContentPage
    {
        public ForthQuestion()
        {
            InitializeComponent();
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void To_ScamResult(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScamResult());
        }
    }
}