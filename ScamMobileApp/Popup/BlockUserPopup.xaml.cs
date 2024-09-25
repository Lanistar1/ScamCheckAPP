using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.Views.Questions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlockUserPopup : PopupPage
    {
        private INavigation _navigation;

        public BlockUserPopup(INavigation navigation, ObservableCollection<ExperienceData> selectedItems)
        {
            InitializeComponent();
            _navigation = navigation;
            BindingContext = new ExperienceDetailViewModel(Navigation, selectedItems);


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