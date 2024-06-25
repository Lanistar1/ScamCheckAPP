using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.Others;
using ScamMobileApp.Views.More;
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
	public partial class ScamQAPopup : PopupPage
    {
        private INavigation _navigation;

        public ScamQAPopup (INavigation navigation)
		{
			InitializeComponent ();
            _navigation = navigation;

            BindingContext = new scamQAdescriptionViewmodel(Navigation);


        }

        private void Close_Popup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(); // Close the popup first
        }

        private async void Confirm(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first
            await _navigation.PushAsync(new QuestionsAndAnswer());
        }
    }
}