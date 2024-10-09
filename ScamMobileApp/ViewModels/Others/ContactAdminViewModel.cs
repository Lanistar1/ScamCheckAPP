using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{

    public class ContactAdminViewModel : BaseViewModel
    {
        public ContactAdminViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _tsk = FetchUserProfile();

            ContactCommand = new Command(async () => await ContactCommandExecute());

        }

        #region Binding Properties

        private GetProfileData profileData;
        public GetProfileData ProfileData
        {
            get => profileData;
            set
            {
                profileData = value;
                OnPropertyChanged(nameof(ProfileData));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string firstname;
        public string FirstName
        {
            get => firstname;
            set
            {
                firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        #endregion


        #region Command
        public Command ContactCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations

        private async Task FetchUserProfile()
        {
            try
            {
                await LoadingPopup.Instance.Show("Loading Profile detail...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserProfileAsync();
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        ProfileData = ResponseData.data;

                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                    }
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    string message = "Error fetching user detail. Do you want to RETRY?";
                    await MessagePopup.Instance.Show(
                        message: message);

                }
                else
                {
                    await MessagePopup.Instance.Show(ErrorData.message);
                }
            }
            catch (Exception ex)
            {
                string message = "Error fetching user detail. Do you want to RETRY?";
                await MessagePopup.Instance.Show(
                    message: message);
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }


        private async Task ContactCommandExecute()
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                await MessagePopup.Instance.Show("Message field should not be empty");

                return;
            }

            try
            {

                await LoadingPopup.Instance.Show("Contacting admin...");

                ContactRequestModel requestPayload = new ContactRequestModel() { email = ProfileData.email, message = Message, name = ProfileData.name, phonenumber = ""};

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.ContactAdminAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Message sent to admin.");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expire.");

                    Application.Current.MainPage = new NavigationPage(new Login());

                }
                else
                {
                    await MessagePopup.Instance.Show(ErrorData.message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }


        #endregion
    }

}
