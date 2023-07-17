using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShareScamExperience : ContentPage
    {
        public ShareScamExperience()
        {
            InitializeComponent();
        }

        private void To_Terms(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsAndConditions());
        }
    }
}