using Rg.Plugins.Popup.Extensions;
using ScamMobileApp.Popup;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoreMenu : ContentPage
    {
        public MoreMenu()
        {
            InitializeComponent();
        }

        private void To_Profile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void To_Terms(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsAndConditions());
        }

        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new LogoutPopup());
        }

        private void To_HelpCenter(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpCenter());
        }

        private void To_ChangePassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }
    }
}