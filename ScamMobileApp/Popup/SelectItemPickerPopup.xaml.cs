using ScamMobileApp.Models.Popup;
using ScamMobileApp.ViewModels.Popup;
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
    public partial class SelectItemPickerPopup
    {
        private TaskCompletionSource<Tuple<string>> _taskCompletionSource;
        public Task<Tuple<string>> PopupClosedTask => _taskCompletionSource.Task;
        public static SelectItemPickerPopup Instance { get; private set; }
        public SelectItemPickerPopupViewModel viewModel = null;
        public SelectItemPickerPopup(List<SelectItemModel> items)
        {
            viewModel = new SelectItemPickerPopupViewModel(Navigation, items);
            InitializeComponent();
            Instance = this;
            BindingContext = viewModel;

        }

        protected override bool OnBackButtonPressed()
        {
            HandleBackButtonPressed();
            return true;
        }

        private async void HandleBackButtonPressed()
        {
            await SelectItemPickerPopupViewModel.Instance.ClosePopUp(string.Empty);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _taskCompletionSource = new TaskCompletionSource<Tuple<string>>();
        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    _taskCompletionSource.SetResult(((SelectItemPickerPopupViewModel)BindingContext).ReturnValue);
        //}


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var returnValue = (((SelectItemPickerPopupViewModel)BindingContext).ReturnValue);

            // If there's no return value available, set a default value or handle it gracefully
            if (returnValue == null)
            {
                _taskCompletionSource.SetResult(Tuple.Create("")); // Set default values
            }
            else
            {
                _taskCompletionSource.SetResult(returnValue);
            }
        }

        protected override bool OnBackgroundClicked()
        {
            // Handle the background click event here
            // You can close the popup just like you would with the close button
            ClosePopup();

            // Return true to prevent the default behavior of closing the popup
            return true;
        }

        private void ClosePopup()
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }
    }
}