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
    public partial class Welcome1 : ContentPage
    {
        public Welcome1()
        {
            InitializeComponent();
        }

        private void To_welcome2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Welcome2());
        }
    }
}