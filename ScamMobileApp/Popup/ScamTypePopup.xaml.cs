using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Views.Questions;
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
	public partial class ScamTypePopup : PopupPage
    {
        private INavigation _navigation;

        public ScamTypePopup (INavigation navigation)
		{
			InitializeComponent ();
            _navigation = navigation;

        }

        private void Close_Popup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(); // Close the popup first
        }

        private async void Confirm(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first
            await _navigation.PushAsync(new TypeOfScam());
        }
    }
}