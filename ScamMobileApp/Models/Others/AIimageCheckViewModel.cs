using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using Plugin.Media;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Service;
using ScamMobileApp.Utils;
using ScamMobileApp.ViewModels;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.Models.Others
{

    public class AIimageCheckViewModel : BaseViewModel
    {
        public AIimageCheckViewModel(INavigation navigation)
        {
            Navigation = navigation;

            PImage = "uploadImage.png";

            uploadImageCommand = new Command(async () => await GetuploadImageCommandExecute());

        }


        #region Bindings

        private CountData feedbackCountData;
        public CountData FeedbackCountData
        {
            get => feedbackCountData;
            set
            {
                feedbackCountData = value;
                OnPropertyChanged(nameof(FeedbackCountData));
            }
        }

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


        private string status;
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string aiGenerated;
        public string AiGenerated
        {
            get => aiGenerated;
            set
            {
                aiGenerated = value;
                OnPropertyChanged(nameof(AiGenerated));
            }
        }

        private string timestamp;
        public string Timestamp
        {
            get => timestamp;
            set
            {
                timestamp = value;
                OnPropertyChanged(nameof(Timestamp));
            }
        }

        private bool showResult = false;
        public bool ShowResult
        {
            get => showResult;
            set
            {
                showResult = value;
                OnPropertyChanged(nameof(ShowResult));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private double height;
        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
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

        private string role;
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private string pimage;
        public string PImage
        {
            get => pimage;
            set
            {
                pimage = value;
                OnPropertyChanged(nameof(PImage));
            }
        }
        #endregion

        #region Commands
        public Command uploadImageCommand { get; }

        #endregion


        #region functions, methods, events and Navigations
        public async Task GetuploadImageCommandExecute()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await MessagePopup.Instance.Show("Picking a photo is not supported.");

                return;
            }

            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 92
            });

            if (file == null)
                return;

            await UploadImage(file);
        }


        private async Task UploadImage(MediaFile file)
        {
            try
            {
                await LoadingPopup.Instance.Show("Uploading Image...");

                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(file.GetStream()), "file", file.Path);

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("http://209.97.184.81:5000/auth/upload-image", content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = JsonConvert.DeserializeObject<pickImageResponseModel>(responseString);
                        var imageUrl = jsonResponse.data.url;

                        //await MessagePopup.Instance.Show("Image uploaded successfully.");

                        // Update the user profile
                        await UpdateUserProfile(imageUrl);
                    }
                    else if ((int)response.StatusCode == 401)
                    {
                        await MessagePopup.Instance.Show("You are not authorized to upload this file.");
                    }
                    else
                    {
                        await MessagePopup.Instance.Show("File upload failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await MessagePopup.Instance.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }


        private async Task UpdateUserProfile(string imageUrl)
        {
            try
            {
                HttpClient client = new HttpClient();

                await LoadingPopup.Instance.Show("Checking image AI level...");

                var profileData = Global.UserProfileData;

                AIImageCheckRequestModel requestPayload = new AIImageCheckRequestModel()
                {  url = imageUrl };


                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(payloadJson);

                string url = Global.AIImageCheckUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"{Global.Token}");


                HttpResponseMessage response;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<AIImageCheckModel>(result);
                    Console.WriteLine("passedjiojiojiojio");

                    ShowResult = true;

                    var testAI = data.data.type.ai_generated * 100; // Convert decimal to percentage
                    AiGenerated = $"{Math.Round(testAI)}%";
                    Status = data.data.status;
                    //Timestamp = data.data.request.timestamp;

                    //========== time stamp conversion code ========
                    double unixTimestamp = data.data.request.timestamp;
                    long seconds = (long)unixTimestamp; // Get whole seconds
                    double milliseconds = (unixTimestamp - seconds) * 1000; // Get fractional milliseconds

                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(seconds)
                                                    .AddMilliseconds(milliseconds);

                    Timestamp = dateTimeOffset.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss"); // Convert to string


                    await MessagePopup.Instance.Show("Check completed.");

                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        PImage = "uploadImage.png";
                    }
                    else
                    {
                        PImage = imageUrl;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    await MessagePopup.Instance.Show("User profile not updated.");

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await MessagePopup.Instance.Show("You are not authorized to perform this action.");
                }
            }
            catch (Exception ex)
            {
                await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }




        //========= check and request permission to use storage ================
        private async Task<PermissionStatus> CheckAndRequestStoragePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status != PermissionStatus.Granted)
            {
                if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
                {
                    await MessagePopup.Instance.Show("Permission Needed. We need storage access to pick and upload images. Please grant the permission.");

                }

                status = await Permissions.RequestAsync<Permissions.StorageRead>();

                if (status != PermissionStatus.Granted)
                {
                    await MessagePopup.Instance.Show("Permission Denied. Storage read permission was not granted. Please enable storage access in your device settings.");

                }
            }
            return status;
        }


        #endregion


    }

}
