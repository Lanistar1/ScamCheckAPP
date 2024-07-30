using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;



namespace ScamMobileApp.ViewModels.Identity
{
    public class GetProfileViewModel : BaseViewModel
    {
        public GetProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;

            //PImage = "myprofile.png";

            Task _tsk = FetchUserProfile();

            UpdateProfileCommand = new Command(async () => await GetUpdateProfileExecute());

        }


        #region Bindings

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

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
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

        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
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
        public Command UpdateProfileCommand { get; }

        #endregion


        #region functions, methods, events and Navigations
        private async Task FetchUserProfile()
        {
            try
            {
                await LoadingPopup.Instance.Show("Loading Profile detail...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserProfileAsync();
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        ProfileData = ResponseData.data;

                        Global.UserProfileData = ProfileData;

                        Name = ProfileData.name;
                        Email = ProfileData.email;
                        Role = ProfileData.role;
                        UserName = ProfileData.username;
                        LastName = ProfileData.lastname;
                        FirstName = ProfileData.firstname;

                        if (string.IsNullOrEmpty(ProfileData.profileImgeUrl))
                        {
                            PImage = "myprofile.png";
                        }
                        else
                        {
                            PImage = ProfileData.profileImgeUrl;
                        }

                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                    }
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    string message = "Error fetching user detail. Do you want to RETRY?";
                    await MessagePopup.Instance.Show(
                        message: message);

                }
                else
                {
                    await MessagePopup.Instance.Show(ErrorData.message);
                }
            }
            catch (Exception ex)
            {
                string message = "Error fetching user detail. Do you want to RETRY?";
                await MessagePopup.Instance.Show(
                    message: message);
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }


        //=========== uploading profile image ==========

        //public async Task GetUpdateProfileExecute()
        //{
        //    // Check and request storage permission
        //    var status = await CheckAndRequestStoragePermission();
        //    if (status != PermissionStatus.Granted)
        //    {
        //        await MessagePopup.Instance.Show("Permission Denied. Storage read permission was not granted. Please enable storage access in your device settings.");

        //        return;
        //    }

        //    try
        //    {
        //        await LoadingPopup.Instance.Show("Uploading Image...");

        //        var result = await FilePicker.PickAsync(PickOptions.Images);

        //        if (result != null)
        //        {
        //            var stream = await result.OpenReadAsync();
        //            byte[] data;
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                stream.CopyTo(ms);
        //                data = ms.ToArray();
        //            }

        //            FileBytesItem fileItem = new FileBytesItem("file", data, result.FileName);

        //            FileUploadResponse response = null;
        //            try
        //            {
        //                response = await CrossFileUploader.Current.UploadFileAsync("http://209.97.184.81:5000/auth/upload-image", fileItem, new Dictionary<string, string>
        //                {
        //                    { "Authorization", Helpers.Global.Token }

        //                    //{ "Authorization", "Bearer " + Helpers.Global.Token }
        //                });
        //            }
        //            catch (Exception ex)
        //            {
        //                await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
        //                return;
        //            }

        //            if (response.StatusCode == 200)
        //            {

        //                await MessagePopup.Instance.Show("Image upload successfully.");

        //                // Parse the response to get the image URL
        //                var jsonResponse = JsonConvert.DeserializeObject<pickImageResponseModel>(response.Message);
        //                var imageUrl = jsonResponse.data.url;

        //                // Update the user profile
        //                await UpdateUserProfile(imageUrl);
        //            }
        //            else if (response.StatusCode == 401)
        //            {
        //                await MessagePopup.Instance.Show("You are not authorized to upload this file.");

        //            }
        //            else
        //            {
        //                await MessagePopup.Instance.Show("File upload fail.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
        //    }
        //}

        public async Task GetUpdateProfileExecute()
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

                        await MessagePopup.Instance.Show("Image uploaded successfully.");

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


        //public async Task GetUpdateProfileExecute()
        //{
        //    // Check and request storage permission
        //    var status = await CheckAndRequestStoragePermission();
        //    if (status != PermissionStatus.Granted)
        //    {
        //        await MessagePopup.Instance.Show("Permission Denied. Storage read permission was not granted. Please enable storage access in your device settings.");

        //        return;
        //    }

        //    try
        //    {
        //        await LoadingPopup.Instance.Show("Uploading Image...");

        //        var result = await FilePicker.PickAsync(PickOptions.Images);

        //        if (result != null)
        //        {
        //            var stream = await result.OpenReadAsync();
        //            byte[] data;
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                stream.CopyTo(ms);
        //                data = ms.ToArray();
        //            }

        //            FileBytesItem fileItem = new FileBytesItem("file", data, result.FileName);

        //            FileUploadResponse response = null;
        //            try
        //            {
        //                response = await CrossFileUploader.Current.UploadFileAsync("http://209.97.184.81:5000/auth/upload-image", fileItem, new Dictionary<string, string>
        //                {
        //                    { "Authorization", Helpers.Global.Token }

        //                    //{ "Authorization", "Bearer " + Helpers.Global.Token }
        //                });
        //            }
        //            catch (Exception ex)
        //            {
        //                await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
        //                return;
        //            }

        //            if (response.StatusCode == 200)
        //            {

        //                await MessagePopup.Instance.Show("Image upload successfully.");

        //                // Parse the response to get the image URL
        //                var jsonResponse = JsonConvert.DeserializeObject<pickImageResponseModel>(response.Message);
        //                var imageUrl = jsonResponse.data.url;

        //                // Update the user profile
        //                await UpdateUserProfile(imageUrl);
        //            }
        //            else if (response.StatusCode == 401)
        //            {
        //                await MessagePopup.Instance.Show("You are not authorized to upload this file.");

        //            }
        //            else
        //            {
        //                await MessagePopup.Instance.Show("File upload fail.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
        //    }
        //}


        private async Task UpdateUserProfile(string imageUrl)
        {
            try
            {
                HttpClient client = new HttpClient();

                await LoadingPopup.Instance.Show("Updating user profile...");

                var profileData = Global.UserProfileData;

                UserProfileRequestModel requestPayload = new UserProfileRequestModel()
                { firstname = profileData.firstname, lastname = profileData.lastname, profileImgeUrl = imageUrl };


                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(payloadJson);

                string url = "http://209.97.184.81:5000/auth/update-user";
                Console.WriteLine(url);
                StringContent content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"{Global.Token}");


                HttpResponseMessage response;
                response = await client.PutAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await MessagePopup.Instance.Show("User Profile updated successfully.");

                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        PImage = "myprofile.png";
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
                Console.WriteLine(ex);
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
