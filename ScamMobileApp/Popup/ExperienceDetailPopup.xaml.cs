using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.ViewModels.Experience;
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
    public partial class ExperienceDetailPopup : PopupPage
    {
        public ExperienceDetailPopup(ObservableCollection<ExperienceData> selectedItems)
        {
            InitializeComponent();
            BindingContext = new ExperienceDetailViewModel(Navigation, selectedItems);

        }

        private async void Close_Popup(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(); // Close the popup first
        }
    }
}