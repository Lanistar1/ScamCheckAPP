using Newtonsoft.Json;
using ScamMobileApp.Converters;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Common;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Models.Others;
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
                var json = JsonConvert.SerializeObject(request);
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

        public async Task<(SignupResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> SignupUserAsync(string email, string password, string username, string firstname, string lastname, string AgeBracket)
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
                    lastname = lastname,
                    ageBracket = AgeBracket
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

        // Contact admin
        public async Task<(ContactResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> ContactAdminAsync(ContactRequestModel requestPayload)
        {
            try
            {
                string url = Global.ContactAdminUrl;
                
                var json = JsonConvert.SerializeObject(requestPayload);
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
                        ContactResponseModel data = JsonConvert.DeserializeObject<ContactResponseModel>(result);
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


        public async Task<(FeedbackCountModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetFeedbackCountAsync()
        {
            try
            {
                string url = Global.FeedbackCountUrl;
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
                        var data = JsonConvert.DeserializeObject<FeedbackCountModel>(result);
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

        // Report post
        public async Task<(ReportScamResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> ReportPostAsync(ReportPostRequestModel requestPayload)
        {
            try
            {
                string url = Global.ReportPostUrl;

                var json = JsonConvert.SerializeObject(requestPayload);
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
                        ReportScamResponseModel data = JsonConvert.DeserializeObject<ReportScamResponseModel>(result);
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


        // Block post
        public async Task<(BlockPostResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> BlockPostAsync(BlockPostRequestModel requestPayload)
        {
            try
            {
                string url = Global.BlockUserUrl;

                var json = JsonConvert.SerializeObject(requestPayload);
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
                        BlockPostResponseModel data = JsonConvert.DeserializeObject<BlockPostResponseModel>(result);
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


        //Flag post
        public async Task<(FlagPostResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> FlagPostAsync(FlagPostRequestModel requestPayload)
        {
            try
            {
                string url = Global.FlagPostUrl;

                var json = JsonConvert.SerializeObject(requestPayload);
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
                        FlagPostResponseModel data = JsonConvert.DeserializeObject<FlagPostResponseModel>(result);
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


        // unwanted keyword
        public async Task<(KeywordResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> AddUnwantedkeywordsAsync(KeywordsRequestModel requestPayload)
        {
            try
            {
                string url = Global.AddUnwantedKeywordsUrl;

                var json = JsonConvert.SerializeObject(requestPayload);
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
                        KeywordResponseModel data = JsonConvert.DeserializeObject<KeywordResponseModel>(result);
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


        // Get unwanted keywords
        public async Task<(GetUnwantedKeywordModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetUnwantedKeywordsAsync()
        {
            try
            {
                string url = Global.GetUnwantedKeywordsUrl;
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
                        var data = JsonConvert.DeserializeObject<GetUnwantedKeywordModel>(result);
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


        // post app rating
        public async Task<(PostRateResponseModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> AddRatingAsync(PostRateRequestModel requestPayload)
        {
            try
            {
                string url = Global.PostAppRatingUrl;

                var json = JsonConvert.SerializeObject(requestPayload);
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
                        PostRateResponseModel data = JsonConvert.DeserializeObject<PostRateResponseModel>(result);
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


        // Get news
        public async Task<(NewsModel ResponseData, ErrorResponseModel ErrorData, int StatusCode)> GetNewsAsync()
        {
            try
            {
                string url = Global.NewsUrl;
                HttpClient client = new HttpClient();

                //client.DefaultRequestHeaders.Add("Authorization", $"{token}");
                HttpResponseMessage response = null;
                ErrorResponseModel errorData;
                response = await client.GetAsync(url);
                int statusCode = (int)response.StatusCode;
                int _status = StringHelper.ConvertStatusCode((int)response.StatusCode);
                string result = await response.Content.ReadAsStringAsync();
                switch (_status)
                {
                    case 200:
                        var data = JsonConvert.DeserializeObject<NewsModel>(result);
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

    }
}
