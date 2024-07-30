using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Identity;
using System;
using System.Data;
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

            //Task _tsk = FetchUserProfile();

            LoginCommand = new Command(async () => await LoginCommandExecute());

            //LoginCommand = new Command(async () => await LoginCommandsExecute());


        }

        #region Binding Properties

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

        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;

            return EmailRegex.IsMatch(Email);
        }


        #endregion


        #region Commands
        public Command LoginCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations
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
        //                var test = ResponseData.data;

                        

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
        //        //else
        //        //{
        //        //    await MessagePopup.Instance.Show(ErrorData.message);
        //        //}
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




        private async Task LoginCommandExecute()
        {
            bool checker = await VerifyBioDataEntry();
            if (checker)
            {
                await LoginCustomerAsync();
            }
        }
        private async Task LoginCustomerAsync()
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
                    email = Email,
                    password = Password
                };

                await LoadingPopup.Instance.Show("Logging In...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.LoginUserAsync(request);

                if (ResponseData != null)
                {
                    Global.UserData = ResponseData.data.profile;
                    Global.Token = ResponseData.data.token;
                    //await MessagePopup.Instance.Show("Login successful");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());
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
            else
            {
                return true;
            }
        }

        #endregion
    }
}
