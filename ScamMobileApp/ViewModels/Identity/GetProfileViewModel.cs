using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{
    public class GetProfileViewModel : BaseViewModel
    {
        public GetProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _tsk = FetchUserProfile();


        }


        #region Bindings

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

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
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

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private double height;
        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

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
        #endregion


        #region functions, methods, events and Navigations
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

                        Global.UserProfileData = ProfileData;

                        Name = ProfileData.name;
                        Email = ProfileData.email;
                        Role = ProfileData.role;
                        UserName = ProfileData.username;
                        LastName = ProfileData.lastname;
                        FirstName = ProfileData.firstname;
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

        #endregion


    }

}
