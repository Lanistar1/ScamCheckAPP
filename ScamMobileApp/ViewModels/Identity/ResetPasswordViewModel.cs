using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public ResetPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;


            ForgotPasswordCommand = new Command(async () => await ForgotPasswordCommandExecute(email));

            ChangePasswordCommand = new Command(async () => await ChangePasswordCommandExecute(oldPassword, newPassword));

            ResetPasswordCommand = new Command(async () => await ResetPasswordCommandExecute(code, newPassword));


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

        private string oldPassword;
        public string OldPassword
        {
            get => oldPassword;
            set
            {
                oldPassword = value;
                OnPropertyChanged(nameof(OldPassword));
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get => newPassword;
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string code;
        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged(nameof(Code));
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


        #region Command
        public Command ForgotPasswordCommand { get; }
        public Command ChangePasswordCommand { get; }
        public Command ResetPasswordCommand { get; }

        #endregion

        #region Events, Methods, Functions and Navigations
        private async Task ForgotPasswordCommandExecute(string email)
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


            try
            {

                await LoadingPopup.Instance.Show("Requesting reset password code...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.ForgotUserPasswordAsync(email);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Password reset link has been sent to your mail. Reset your password and login with your new password here.");

                    await Navigation.PopAsync();
                    //await Navigation.PushAsync(new EnterOtp());
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Token Expire.");
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

        private async Task ChangePasswordCommandExecute(string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(OldPassword))
                {
                    await MessagePopup.Instance.Show("Old password field should not be empty");

                    return;
                }

                if (string.IsNullOrWhiteSpace(NewPassword))
                {
                    await MessagePopup.Instance.Show("New password field should not be empty");

                    return;
                }


                if (OldPassword == NewPassword)
                {
                    await MessagePopup.Instance.Show("Old password and new password should not be the same");

                    return;
                }
                else
                {
                    // do something
                }

                await LoadingPopup.Instance.Show("Changing password...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.ChangeUserPasswordAsync(oldPassword, newPassword);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Password change successfully");

                    await Navigation.PushAsync(new Login());
                }

                else if (ErrorData != null && StatusCode == 401)
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

        private async Task ResetPasswordCommandExecute(string code, string newPassword)
        {
            try
            {

                await LoadingPopup.Instance.Show("Reseting password...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.ResetUserPasswordAsync(code, newPassword);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Password reset successfully");

                    await Navigation.PushAsync(new Login());
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Invalid code. Please check and try again");
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
