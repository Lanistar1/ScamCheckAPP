using Newtonsoft.Json;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Service;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Home;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Identity
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;


            LoginCommand = new Command(async () => await LoginCommandExecute(email, password));

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


        #region Events, Methods, Functions and Navigations
        public Command LoginCommand { get; }
        #endregion

        #region
        private async Task LoginCommandExecute(string email, string password)
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
            try
            {

                await LoadingPopup.Instance.Show("Logging In...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.LoginUserAsync(Email, Password);

                if (ResponseData != null)
                {
                    Global.UserData = ResponseData.data.profile;
                    Global.Token = ResponseData.data.token;
                    await MessagePopup.Instance.Show("Login successful");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());
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

        private async Task LoginCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(Email))
                {
                   
                    await Application.Current.MainPage.DisplayAlert("Email field not correct", "Field should not be empty", "OK");
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
                        // do something
                        //bool isEmail = Regex.IsMatch(Username, EmailRegex);
                        await Application.Current.MainPage.DisplayAlert("Email field not correct", "Field must contain @ and .com ", "OK");
                        return;
                    }
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Password field not correct", "Field should not be empty", "OK");
                    return;
                }

                HttpClient client = new HttpClient();

                await LoadingPopup.Instance.Show("Logging in...");

                LoginRequestModel request = new LoginRequestModel { email = Email, password = Password };

                string body = JsonConvert.SerializeObject(request);
                Console.WriteLine(Email);
                Console.WriteLine(Password);

                string url = Global.LoginUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                    Console.WriteLine(data.data.token);
                   

                    await Application.Current.MainPage.DisplayAlert("User Login Successful", "", "OK");
                    
                    Console.WriteLine("Good");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                   
                    await Application.Current.MainPage.DisplayAlert("Login not successfully", "Username or password not correct", "OK");
                    
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Login not successfully", "Username or password not correct", "OK");
                    
                }
                else
                {
                    LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);

                    await Application.Current.MainPage.DisplayAlert("Something went wrong", "Please try again later", "OK");
                    
                    response.Dispose();
                }

            }
            catch (Exception ex)
            {
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
