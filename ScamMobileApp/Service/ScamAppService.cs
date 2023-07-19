using Newtonsoft.Json;
using ScamMobileApp.Converters;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Common;
using ScamMobileApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScamMobileApp.Service
{
    public class ScamAppService
    {
        HttpClient client;
        ProfileData userData = Global.UserData == null ? null : Global.UserData;
        string token = Global.Token;

        public async Task<(LoginResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> LoginUserAsync(string email, string password)
        {
            try
            {
                string url = Global.LoginUrl;

                var loginData = new LoginRequestModel
                {
                    email = email,
                    password = password
                };
                var json = JsonConvert.SerializeObject(loginData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;
                
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                        return (data, null, statusCode);
                    case 300:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 400:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 500:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 0:
                        return (null, null, statusCode);
                    default:
                        return (null, null, statusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }

        }

        public async Task<(SignupResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> SignupUserAsync(string email, string password, string username, string firstname, string lastname)
        {
            try
            {
                string url = Global.SignupUrl;

                var RegisterData = new SignupRequestModel
                {
                    email = email,
                    password = password,
                    username = username,
                    firstname = firstname,
                    lastname = lastname
                };
                var json = JsonConvert.SerializeObject(RegisterData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        SignupResponseModel data = JsonConvert.DeserializeObject<SignupResponseModel>(result);
                        return (data, null, statusCode);
                    case 300:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 400:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 500:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 0:
                        return (null, null, statusCode);
                    default:
                        return (null, null, statusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }

        }

        public async Task<(ForgetPasswordResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> ForgotUserPasswordAsync(string email)
        {
            try
            {
                string url = Global.ForgotPassswordUrl;

                var ResetPasswordData = new ForgetPasswordRequest
                {
                    email = email,
                    
                };
                var json = JsonConvert.SerializeObject(ResetPasswordData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        ForgetPasswordResponseModel data = JsonConvert.DeserializeObject<ForgetPasswordResponseModel>(result);
                        return (data, null, statusCode);
                    case 300:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 400:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 500:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 0:
                        return (null, null, statusCode);
                    default:
                        return (null, null, statusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }

        }


        public async Task<(ChangePasswordResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> ChangeUserPasswordAsync(string oldPassword, string newPassword)
        {
            try
            {
                string url = Global.ChangePasswordUrl;

                var ChangePasswordData = new ChangepasswordRequest
                {
                    oldPassword = oldPassword, 
                    newPassword = newPassword

                };
                var json = JsonConvert.SerializeObject(ChangePasswordData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                var response = await client.PutAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        ChangePasswordResponseModel data = JsonConvert.DeserializeObject<ChangePasswordResponseModel>(result);
                        return (data, null, statusCode);
                    case 300:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 400:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 500:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 0:
                        return (null, null, statusCode);
                    default:
                        return (null, null, statusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }

        }


        public async Task<(ResetPasswordResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> ResetUserPasswordAsync(string code, string newPassword)
        {
            try
            {
                string url = Global.ResetPassswordUrl;

                var ResetPasswordData = new ResetPasswordRequest
                {
                    code = code,
                    newPassword = newPassword

                };
                var json = JsonConvert.SerializeObject(ResetPasswordData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        ResetPasswordResponseModel data = JsonConvert.DeserializeObject<ResetPasswordResponseModel>(result);
                        return (data, null, statusCode);
                    case 300:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 400:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 500:
                        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                        return (null, errorData, statusCode);
                    case 0:
                        return (null, null, statusCode);
                    default:
                        return (null, null, statusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }

        }

    }
}
