using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPopup : PopupPage
    {
        public LogoutPopup()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void Close_Popup(object sender, EventArgs e)
        {
            var popupNavigation = Rg.Plugins.Popup.Services.PopupNavigation.Instance;

            // Close the current popup
            await popupNavigation.PopAsync();

            //PopupNavigation.RemovePageAsync(this);
        }

        [Obsolete]
        private async void Confirm(object sender, EventArgs e)
        {
            Global.Token = null;
            await PopupNavigation.Instance.PopAsync(); // Close the popup first

            //await PopupNavigation.RemovePageAsync(this);
            Application.Current.MainPage = new Login();

        }
    }
}