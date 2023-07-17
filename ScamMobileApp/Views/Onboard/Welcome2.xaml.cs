using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Onboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome2 : ContentPage
    {
        public Welcome2()
        {
            InitializeComponent();
        }

        private void To_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}