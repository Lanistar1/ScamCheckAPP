using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.Views.More;
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
    public partial class TakeActionPopup : PopupPage
    {
        private INavigation _navigation;

        public ObservableCollection<ExperienceData> selectedItems;
        public ObservableCollection<ExperienceData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        public TakeActionPopup(INavigation navigation, ObservableCollection<ExperienceData> selectedItems)
        {
            InitializeComponent();

            _navigation = navigation;

            SelectedItems = selectedItems;

            BindingContext = new ExperienceDetailViewModel(Navigation, selectedItems);

        }

        private void Close_Popup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(); // Close the popup first
        }

        private async void BlockUser(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first

            await PopupNavigation.Instance.PushAsync(new BlockUserPopup(Navigation, SelectedItems));

        }

        private async void MuteUser(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first

            await PopupNavigation.Instance.PushAsync(new MuteUserPopup(Navigation, SelectedItems));

        }

        private async void ReportUser(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first
            await Task.Delay(200); // Small delay

            await _navigation.PushAsync(new ReportPostPage(SelectedItems));
        }
    }
}