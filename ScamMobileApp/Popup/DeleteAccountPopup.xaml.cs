using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels;
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
    public partial class DeleteAccountPopup : PopupPage
    {
        DeleteAccountViewModel pageViewModel = null;

        public DeleteAccountPopup()
        {
            pageViewModel = new DeleteAccountViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }

        private async void Close_Popup(object sender, EventArgs e)
        {
            //PopupNavigation.RemovePageAsync(this);

            // Get the IPopupNavigation instance
            await PopupNavigation.Instance.PopAsync(); // Close the popup first

        }
    }
}