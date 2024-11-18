using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            SelectAgeCommand = new Command(async () => await SelectAgeCommandExecute());


        }

        #region Binding Properties

        private string ageBracket;
        public string AgeBracket
        {
            get => ageBracket;
            set
            {
                ageBracket = value;
                OnPropertyChanged(nameof(AgeBracket));
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


        #region Commands
        public Command SignupCommand { get; }
        public Command SelectAgeCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations
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
            // Check for minimum length of 8 characters
            else if (Password.Length < 8)
            {
                await MessagePopup.Instance.Show("Password must be at least 8 characters long.");
                return;
            }

            // Check for at least one number
            else if (!Password.Any(char.IsDigit))
            {
                await MessagePopup.Instance.Show("Password must contain at least one number.");
                return;
            }

            // Check for at least one symbol
            else if (!Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                await MessagePopup.Instance.Show("Password must contain at least one symbol.");
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

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.SignupUserAsync(email, password, username, firstname, lastname, AgeBracket);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Sign up successful. Check your mail to verify your account.");

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


        private async Task SelectAgeCommandExecute()
        {

            List<SelectItemModel> ageTypes = new List<SelectItemModel>()
            {
                new SelectItemModel(1,"15-18"),
                new SelectItemModel(2,"18-24"),
                new SelectItemModel(3,"25-34"),
                new SelectItemModel(4,"35-44"),
                new SelectItemModel(5,"45-54"),
                new SelectItemModel(6,"55-64"),
                new SelectItemModel(7,"65 & above"),
            };
            var popup = new SelectItemPickerPopup(ageTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            AgeBracket = result.Item1;
        }
        #endregion
    }

}
