using Newtonsoft.Json;
using ScamMobileApp.Converters;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Common;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
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
        //HttpClient client;
        ProfileData userData = Global.UserData == null ? null : Global.UserData;
        string token = Global.Token;

        public static class HttpClientSingleton
        {
            private static readonly HttpClient _httpClientInstance;

            static HttpClientSingleton()
            {
                _httpClientInstance = new HttpClient();
            }

            public static HttpClient Instance => _httpClientInstance;
        }

        public async Task<(LoginResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> LoginUserAsync(LoginRequestModel request)
        {
            try
            {
                string url = Global.LoginUrl;

                //var loginData = new LoginRequestModel
                //{
                //    email = email,
                //    password = password
                //};
                if (string.IsNullOrEmpty(url))
                {
                    Console.WriteLine("Login URL is null or empty.");
                    return (null, null, 0);
                }

                if (request == null)
                {
                    Console.WriteLine("Login request is null.");
                    return (null, null, 0);
                }
                var json = JsonConvert.SerializeObject(request);
                StringContent content;

                try
                {
                    content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception while creating StringContent: " + ex.Message);
                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                    return (null, null, 0);
                }
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    ErrorResponseModel errorData;

                    HttpClient client = HttpClientSingleton.Instance;
                    Console.WriteLine("Sending POST request to: " + url);
                    var response = await client.PostAsync(url, content);
                    Console.WriteLine("Received response with status code: " + response.StatusCode);

                    int statusCode = (int)response.StatusCode;
                    int _status = StringHelper.ConvertStatusCode(statusCode);
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response content: " + result);

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
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine("HTTP Request Exception: " + httpEx.Message);
                    return (null, null, 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception during POST request: " + ex.Message);
                    return (null, null, 0);
                }

                //HttpClient client = new HttpClient();
                //HttpClient client = HttpClientSingleton.Instance;

                //var response = await client.PostAsync(url, content);
                //int statusCode = (int)response.StatusCode;
                //int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                //string result = await response.Content.ReadAsStringAsync();
                //switch (_status)
                //{
                //    case 200:
                //        LoginResponseModel data = JsonConvert.DeserializeObject<LoginResponseModel>(result);
                //        return (data, null, statusCode);
                //    case 300:
                //        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                //        return (null, errorData, statusCode);
                //    case 400:
                //        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                //        return (null, errorData, statusCode);
                //    case 500:
                //        errorData = JsonConvert.DeserializeObject<ErrorResponseModel>(result);
                //        return (null, errorData, statusCode);
                //    case 0:
                //        return (null, null, statusCode);
                //    default:
                //        return (null, null, statusCode);
                //}

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

        // Delete
        public async Task<(DeleteAccountModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> DeleteProfileAsync()
        {
            try
            {
                string url = Global.DeleteProfileUrl;

                //var ResetPasswordData = new ResetPasswordRequest
                //{
                //    code = code,
                //    newPassword = newPassword

                //};
                //var json = JsonConvert.SerializeObject(ResetPasswordData);
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                var response = await client.DeleteAsync(url);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        DeleteAccountModel data = JsonConvert.DeserializeObject<DeleteAccountModel>(result);
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


        public async Task<(GetProfileModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetUserProfileAsync()
        {
            try
            {
                string url = Global.GetProfileUrl;
                HttpClient client = new HttpClient();

                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.Token}");
                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                HttpResponseMessage response = null;
                ErrorResponseModel errorData;
                response = await client.GetAsync(url);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        var data = JsonConvert.DeserializeObject<GetProfileModel>(result);
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
                        return (null, null, 0);
                    default:
                        return (null, null, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }
        }

        public async Task<(GetExperienceModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetUserExperienceAsync()
        {
            try
            {
                string url = Global.GetExperienceUrl;
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                HttpResponseMessage response = null;
                ErrorResponseModel errorData;
                response = await client.GetAsync(url);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        var data = JsonConvert.DeserializeObject<GetExperienceModel>(result);
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
                        return (null, null, 0);
                    default:
                        return (null, null, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }
        }

        public async Task<(GetFeedbackModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetUserFeedBackAsync(string limit, string offset)
        {
            try
            {
                string url = $"{Global.GetFeedbackUrl}?limit={limit}&offset={offset}"; 
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                HttpResponseMessage response = null;
                ErrorResponseModel errorData;
                response = await client.GetAsync(url);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        var data = JsonConvert.DeserializeObject<GetFeedbackModel>(result);
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
                        return (null, null, 0);
                    default:
                        return (null, null, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (null, null, 0);
            }
        }

        public async Task<(PostExperienceResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> PostExperienceAsync(string title, string message)
        {
            try
            {
                string url = Global.PostExperienceUrl;

                var ExperienceData = new PostExperienceRequestModel
                {
                    message = message, 
                    title = title
                };
                var json = JsonConvert.SerializeObject(ExperienceData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                ErrorResponseModel errorData;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                var response = await client.PostAsync(url, content);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        PostExperienceResponseModel data = JsonConvert.DeserializeObject<PostExperienceResponseModel>(result);
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
