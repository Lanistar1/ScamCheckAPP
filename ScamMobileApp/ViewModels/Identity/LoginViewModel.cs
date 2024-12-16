using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;

            HandlePageBindingAndView();

            LoginCommand = new Command(async () => await LoginCommandExecute());

            UnlockDeviceCommand = new Command(async () => await UnlockDeviceCommandExecute());

            //LoginCommand = new Command(async () => await LoginCommandsExecute());

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

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string email = Preferences.Get(nameof(Email), string.Empty);
        public string Email
        {
            get => email;
            set
            {
                //email = value;
                SetProperty(ref email, value);
                Global.UserName = email;
                Preferences.Set(nameof(Email), value);
                OnPropertyChanged(nameof(Email));
            }
        }

        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            return EmailRegex.IsMatch(Email);
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

        private bool isNoFirstTimeUser;
        public bool IsNoFirstTimeUser
        {
            get => isNoFirstTimeUser;
            set
            {
                isNoFirstTimeUser = value;
                OnPropertyChanged(nameof(IsNoFirstTimeUser));
            }
        }

        private bool isFirstTimeUser;
        public bool IsFirstTimeUser
        {
            get => isFirstTimeUser;
            set
            {
                isFirstTimeUser = value;
                OnPropertyChanged(nameof(IsFirstTimeUser));
            }
        }

        private string greetings;
        public string Greetings
        {
            get
            {
                return greetings;
            }
            set
            {
                greetings = value;
                OnPropertyChanged(nameof(Greetings));
            }
        }

        public string username;
        public string Username
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                Global.UserName = username;
                Preferences.Set(nameof(Username), value);
                OnPropertyChanged(nameof(Username));
            }
        }

        #endregion


        #region Commands
        public Command LoginCommand { get; }
        public Command UnlockDeviceCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations

        private async Task LoginCustomerAsync()
        {

            try
            {
                if (IsFirstTimeUser == true)
                {
                    var _userId = Email.Trim();

                    Username = _userId;
                    Global.UserName = username;
                    await LoginCommandsExecute(Username, Password);
                }
                else
                {
                    Username = Email.Trim();
                    Global.UserName = Username;

                    Password = Password;
                    await LoginCommandsExecute(Username, Password);
                }

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine(message);
            }
            finally
            {
                //IsBtnEnabled = true;
                await LoadingPopup.Instance.Hide();
            }
        }


        private void HandleTimeZoneGreetings()
        {
            try
            {
                int dateTime = DateTime.Now.Hour;
                if (dateTime <= 12)
                {
                    Greetings = "Good Morning!";
                }
                else if (dateTime > 12 && dateTime <= 16)
                {
                    Greetings = "Good Afternoon";
                }
                else if (dateTime > 16 && dateTime <= 20)
                {
                    Greetings = "Good Evening";
                }
                else
                {
                    Greetings = "Good Night";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }


        

        private async Task LoginCommandExecute()
        {
            bool checker = await VerifyBioDataEntry();
            if (checker)
            {
                await LoginCustomerAsync();
            }
        }

        private async Task LoginCommandsExecute(string Username, string password)
        {

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await MessagePopup.Instance.Show("Internet connection not available");
                return;
            }

            try
            {
                LoginRequestModel request = new LoginRequestModel()
                { 
                    email = Username,
                    password = password
                };

                await LoadingPopup.Instance.Show("Logging In...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.LoginUserAsync(request);

                if (ResponseData != null)
                {
                    Global.UserData = ResponseData.data.profile;
                    Global.Token = ResponseData.data.token;
                    //await MessagePopup.Instance.Show("Login successful");

                    //await FetchUserProfile();

                    //Application.Current.MainPage = new NavigationPage(new Tabbed());

                    //await Navigation.PushAsync(new Tabbed());

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage = new NavigationPage(new NewDashboard());
                    });
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Invalid credentials. Please check and try again");
                }
                else if (ErrorData != null && StatusCode == 400)
                {
                    await MessagePopup.Instance.Show("Invalid credentials. Please check and try again");
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

        private async Task<bool> VerifyBioDataEntry()
        {
            //if (string.IsNullOrWhiteSpace(Title))
            //{
            //    await MessagePopup.Instance.Show("Select title to continue.");
            //    return false;
            //}


            var emailTrim = Email.Trim();
            if (string.IsNullOrWhiteSpace(emailTrim))
            {
                await MessagePopup.Instance.Show("Email field should not be empty.");
                return false;
            }
            else
            {
                var x = EmailRegex.Match(emailTrim);
                if (x.Success)
                {
                    // do something
                }
                else
                {

                    await MessagePopup.Instance.Show("Email field not correct. Field must contain @ and .com ");

                    return false;
                }
            }


            if (string.IsNullOrWhiteSpace(Password))
            {
                await MessagePopup.Instance.Show("Password field should not be empty.");
                return false;
            }
            else if (Password.Length < 8 || !Password.Any(char.IsDigit) || !Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                await MessagePopup.Instance.Show("Password field must contain atleast a number, a special character and must be atleast 8 characters long.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //======== handling page bindings
        public async void HandlePageBindingAndView()
        {

            string username = await SecureStorage.GetAsync("username");
            string firstName = await SecureStorage.GetAsync("CurrentUserFirstName");
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(firstName))
            {
                IsFirstTimeUser = true;
                IsNoFirstTimeUser = false;
            }
            else
            {
                IsFirstTimeUser = false;
                IsNoFirstTimeUser = true;
                FirstName = firstName;
            }


        }

        //private async Task FetchUserProfile()
        //{
        //    try
        //    {
        //        await LoadingPopup.Instance.Show("Loading Profile detail...");

        //        var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserProfileAsync();
        //        if (ResponseData != null)
        //        {
        //            if (ResponseData.data != null)
        //            {
        //                ProfileData = ResponseData.data;

        //                await SecureStorage.SetAsync("username", ProfileData.email);
        //                await SecureStorage.SetAsync("CurrentUserFirstName", ProfileData.firstname);

        //                FirstName = ProfileData.firstname;
        //                Global.firstName = FirstName;

        //            }
        //            else
        //            {
        //                await MessagePopup.Instance.Show(ErrorData.message);
        //            }
        //        }
        //        else if (ErrorData != null && StatusCode == 401)
        //        {
        //            Application.Current.MainPage = new NavigationPage(new Login());
        //        }
        //        else if (ErrorData != null)
        //        {
        //            string message = "Error fetching user detail. Do you want to RETRY?";
        //            await MessagePopup.Instance.Show(
        //                message: message);

        //        }
        //        else
        //        {
        //            await MessagePopup.Instance.Show(ErrorData.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = "Error fetching user detail. Do you want to RETRY?";
        //        await MessagePopup.Instance.Show(
        //            message: message);
        //        Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        await LoadingPopup.Instance.Hide();
        //    }
        //}


        private async Task UnlockDeviceCommandExecute()
        {

            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    await UnlockDeviceRequest();
                }
                else
                {
                    await UnlockDeviceForiOsUser();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task UnlockDeviceRequest()
        {
            try
            {
                await LoadingPopup.Instance.Show("Unlocking device. Please wait...");
                var _userId = await SecureStorage.GetAsync("CurrentUserId");
                string _appId = "Customer_app";
                //remove later when unlockdevice is implemented on v2
                IsFirstTimeUser = true;
                IsNoFirstTimeUser = false;
                SecureStorage.Remove("username");
                SecureStorage.Remove("CurrentUserFirstName");
                Username = string.Empty;
                Email = string.Empty;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }

        private async Task UnlockDeviceForiOsUser()
        {
            try
            {
                await LoadingPopup.Instance.Show("Unlocking device. Please wait...");
                await Task.Delay(1000);
                IsFirstTimeUser = true;
                IsNoFirstTimeUser = false;
                SecureStorage.Remove("username");
                SecureStorage.Remove("CurrentUserProfileId");
                SecureStorage.Remove("CurrentUserFirstName");
                SecureStorage.Remove("CurrentUserPassword");

                Username = string.Empty;
                Email = string.Empty;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }


        #endregion
    }
}
