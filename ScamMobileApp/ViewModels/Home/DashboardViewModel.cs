using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Home;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Home
{
    public class DashboardViewModel : BaseViewModel
    {
        //private INavigation Navigation;

        #region Bindings
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<GetFeedbackData> SelectedItems = new ObservableCollection<GetFeedbackData>();

        private ObservableCollection<DashboardModel> dashboard;
        public ObservableCollection<DashboardModel> Dashboard
        {
            get => dashboard;
            set
            {
                dashboard = value;
                OnPropertyChanged(nameof(Dashboard));
            }
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private ObservableCollection<GetFeedbackData> feedbackData;
        public ObservableCollection<GetFeedbackData> FeedbackData
        {
            get => feedbackData;
            set
            {
                feedbackData = value;
                OnPropertyChanged(nameof(FeedbackData));
            }
        }


        private string emptyPlaceholder;
        public string EmptyPlaceholder
        {
            get => emptyPlaceholder;
            set
            {
                emptyPlaceholder = value;
                OnPropertyChanged(nameof(EmptyPlaceholder));
            }
        }

        private string offset = "0";
        public string Offset
        {
            get => offset;
            set
            {
                offset = value;
                OnPropertyChanged(nameof(Offset));
            }
        }

        private string limit = "6";
        public string Limit
        {
            get => limit;
            set
            {
                limit = value;
                OnPropertyChanged(nameof(Limit));
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
        public Command TappedCommand { get; }

        #endregion

        #region functions
        public DashboardViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Title = "Scam Q&A";

            Task _task = FetchFeedback(limit, offset);
            Task _tsk = FetchUserProfile();


            TappedCommand = new Command<GetFeedbackData>(async (model) => await GetTappedExecute(model));

            Dashboard = new ObservableCollection<DashboardModel>{
                new DashboardModel { ScamType = "Phishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Vishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Smishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Investment scam check", Date = "04/08/2023"},

             };

            Username = Global.UserData.username;
        }


        // Endpoint to fetch user details
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


                        if (string.IsNullOrEmpty(ProfileData.profileImgeUrl))
                        {
                            PImage = "dashboardImage.png";
                        }
                        else
                        {
                            PImage = ProfileData.profileImgeUrl;
                        }

                        await SecureStorage.SetAsync("username", ProfileData.email);
                        await SecureStorage.SetAsync("CurrentUserFirstName", ProfileData.firstname);

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



        private async Task GetTappedExecute(GetFeedbackData model)
        {
            try
            {
                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (SelectedItems.Count > 0)
                {
                    SelectedItems.Clear();
                }
                SelectedItems.Add(model);

                await Navigation.PushAsync(new FeedbackDetailPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private async Task FetchFeedback(string limit, string offset)
        {
            try
            {
                await LoadingPopup.Instance.Show("Fetching Feedbacks...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserFeedBackAsync(limit, offset);
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        if (ResponseData.data.Count > 0)
                        {
                            FeedbackData = ResponseData.data;
                        }
                        else
                        {
                            EmptyPlaceholder = "No Feedback found.";
                        }
                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                        EmptyPlaceholder = "No Feedback found.";

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

        #endregion




    }
}
