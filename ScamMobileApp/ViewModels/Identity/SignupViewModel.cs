using ScamMobileApp.Helpers;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{

    public class SignupViewModel : BaseViewModel
    {
        public SignupViewModel(INavigation navigation)
        {
            Navigation = navigation;


            SignupCommand = new Command(async () => await SignupCommandExecute(email, password, username, firstname, lastname));


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

        private string lastname;
        public string LastName
        {
            get => lastname;
            set
            {
                lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string username;
        public string UserName
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        
        private string confirmPassword;
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
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


        #region Events, Methods, Functions and Navigations
        public Command SignupCommand { get; }
        #endregion

        #region
        private async Task SignupCommandExecute(string email, string password, string username, string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                await MessagePopup.Instance.Show("Email field should not be empty");

            }
            else
            {
                var x = EmailRegex.Match(Email);
                if (x.Success)
                {
                    // do something
                }
                else
                {

                    await MessagePopup.Instance.Show("Email field not correct. Field must contain @ and .com ");

                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                await MessagePopup.Instance.Show("Password field should not be empty");

                return;
            }


            if (Password == ConfirmPassword)
            {
                // do something
            }
            else
            {
                await MessagePopup.Instance.Show("Password and confirm password are not the same");

                return;
            }

            try
            {

                await LoadingPopup.Instance.Show("Registering...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.SignupUserAsync(email, password, username, firstname, lastname);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Sign up successful");

                    await Navigation.PushAsync(new Login());
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Invalid credentials. Please make sure all field are fill");
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
