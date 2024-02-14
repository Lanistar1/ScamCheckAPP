using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{

    public class DeleteAccountViewModel : BaseViewModel
    {
        public DeleteAccountViewModel(INavigation navigation)
        {
            Navigation = navigation;

            DeleteCommand = new Command(async () => await DeleteCommandExecute());


        }


        #region Bindings
        private string role;
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        #endregion

        #region Commands
        public Command DeleteCommand { get; }

        #endregion


        #region functions, methods, events and Navigations
        [Obsolete]
        private async Task DeleteCommandExecute()
        {
            try
            {
                await PopupNavigation.PopAsync();


                await LoadingPopup.Instance.Show("Deleting account. Please wait...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.DeleteProfileAsync();
                if (ResponseData != null && StatusCode == 200)
                {

                    await MessagePopup.Instance.Show("Account delete successfully.");

                    Application.Current.MainPage = new NavigationPage(new Login());

                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    await MessagePopup.Instance.Show(ErrorData.message);

                }
                else
                {
                    await MessagePopup.Instance.Show(ErrorData.message);
                }
            }
            catch (Exception ex)
            {
                string message = "Something went wrong. Do you want to RETRY?";
                await MessagePopup.Instance.Show(
                    message: message);
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }

        #endregion


    }

}
