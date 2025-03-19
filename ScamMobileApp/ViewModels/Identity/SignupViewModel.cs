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
            SelectGenderCommand = new Command(async () => await SelectGenderCommandExecute());
            SelectCountryCommand = new Command(async () => await SelectCountryCommandExecute());



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

        private string gender;
        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
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
        public Command SelectGenderCommand { get; }
        public Command SelectCountryCommand { get; }
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

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.SignupUserAsync(email, password, username, firstname, lastname, AgeBracket, Gender, Country);

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


        private async Task SelectGenderCommandExecute()
        {
            List<SelectItemModel> genderOptions = new List<SelectItemModel>()
            {
                new SelectItemModel(1, "Male"),
                new SelectItemModel(2, "Female"),
                new SelectItemModel(3, "Others"),
            };

            var popup = new SelectItemPickerPopup(genderOptions);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Gender = result.Item1;
        }


        private async Task SelectCountryCommandExecute()
        {
            List<SelectItemModel> countryOptions = new List<SelectItemModel>()
            {
                 new SelectItemModel(1,"Australia"),
                new SelectItemModel(2,"Argentina"),
                new SelectItemModel(3,"Austria"),
                new SelectItemModel(4,"Belgium"),
                new SelectItemModel(5,"Brazil"),
                new SelectItemModel(6,"Bulgaria"),
                new SelectItemModel(7,"Canada"),
                new SelectItemModel(8,"China"),
                new SelectItemModel(9,"Croatia"),
                new SelectItemModel(10,"Czech Republic"),
                new SelectItemModel(11,"Denmark"),
                new SelectItemModel(12,"Egypt"),
                new SelectItemModel(13,"Estonia"),
                new SelectItemModel(14,"Finland"),
                new SelectItemModel(15,"France"),
                new SelectItemModel(16,"Germany"),
                new SelectItemModel(17,"Greece"),
                new SelectItemModel(18,"Hungary"),
                new SelectItemModel(19,"India"),
                new SelectItemModel(20,"Indonesia"),
                new SelectItemModel(21,"Ireland"),
                new SelectItemModel(22,"Israel"),
                new SelectItemModel(23,"Italy"),
                new SelectItemModel(24,"Japan"),
                new SelectItemModel(25,"Latvia"),
                new SelectItemModel(26,"Lithuania"),
                new SelectItemModel(27,"Malaysia"),
                new SelectItemModel(28,"Mauritius"),
                new SelectItemModel(29,"Mexico"),
                new SelectItemModel(30,"Netherland"),
                new SelectItemModel(31,"New Zealand"),
                new SelectItemModel(32,"Norway"),
                new SelectItemModel(33,"Pakistan"),
                new SelectItemModel(34,"Philippines"),
                new SelectItemModel(35,"Poland"),
                new SelectItemModel(36,"Portugal"),
                new SelectItemModel(37,"Romania"),
                new SelectItemModel(38,"Saudi Arabia"),
                new SelectItemModel(39,"Serbia"),
                new SelectItemModel(40,"Singapore"),
                new SelectItemModel(41,"Slovakia"),
                new SelectItemModel(42,"Slovenia"),
                new SelectItemModel(43,"South Africa"),
                new SelectItemModel(44,"South Korea"),
                new SelectItemModel(45,"Spain"),
                new SelectItemModel(46,"Sri Lanka"),
                new SelectItemModel(47,"Sweden"),
                new SelectItemModel(48,"Switzerland"),
                new SelectItemModel(49,"Thailand"),
                new SelectItemModel(50,"Turkey"),
                new SelectItemModel(51,"Ukraine"),
                new SelectItemModel(52,"United Arab Emirate"),
                new SelectItemModel(53,"United Kingdom"),
                new SelectItemModel(54,"United State of America"),
            };

            var popup = new SelectItemPickerPopup(countryOptions);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Country = result.Item1;
        }

        #endregion
    }

}
