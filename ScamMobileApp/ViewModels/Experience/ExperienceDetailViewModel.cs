
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Experience
{
    public class ExperienceDetailViewModel : BaseViewModel
    {
        public ExperienceDetailViewModel(INavigation navigation, ObservableCollection<ExperienceData> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            UserExperienceData = new ObservableCollection<ExperienceData>(SelectedItems);

            Message = UserExperienceData.FirstOrDefault().message;

            ExperienceId = UserExperienceData.FirstOrDefault()._id;
            UserId = UserExperienceData.FirstOrDefault().userDetails._id;


            //FirstName = UserExperienceData.FirstOrDefault().userDetails.firstname;
            //LastName = UserExperienceData.FirstOrDefault().userDetails.lastname;

            FirstName = UserExperienceData.FirstOrDefault()?.userDetails?.firstname ?? "Default FirstName";
            LastName = UserExperienceData.FirstOrDefault()?.userDetails?.lastname ?? "Default LastName";


            BlockUser = $"Block {FirstName + " " + LastName}";
            MuteUser = $"Flag {FirstName + " " + LastName}";

            BlockPost = $"{FirstName + " " + LastName} will no longer be able to see your posts, and you will not see any post or notifications from {FirstName + " " + LastName}.";

            MutePost = $"You won’t see posts from {FirstName + " " + LastName}  or get notifications about them. They won’t know they’ve been muted.";

            BlockTitle = $"Block {FirstName + " " + LastName}";
            MuteTitle = $"Flag {FirstName + " " + LastName}";

            TappedCommand = new Command(async () => await GetTappedExecute());

            SelectPageCommand = new Command(async () => await SelectPageCommandExecute());

            ReportPostCommand = new Command(async () => await ReportPostCommandExecute());

            BlockPostCommand = new Command(async () => await BlockPostCommandExecute());

            FlagPostCommand = new Command(async () => await FlagPostCommandExecute());


        }


        #region Bindings

        public ObservableCollection<ExperienceData> selectedItems;
        public ObservableCollection<ExperienceData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<ExperienceData> userExperienceData;
        public ObservableCollection<ExperienceData> UserExperienceData
        {
            get => userExperienceData;
            set
            {
                userExperienceData = value;
                OnPropertyChanged(nameof(UserExperienceData));
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

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string blockUser;
        public string BlockUser
        {
            get => blockUser;
            set
            {
                blockUser = value;
                OnPropertyChanged(nameof(BlockUser));
            }
        }

        private string muteUser;
        public string MuteUser
        {
            get => muteUser;
            set
            {
                muteUser = value;
                OnPropertyChanged(nameof(MuteUser));
            }
        }

        private string productName;
        public string ProductName
        {
            get => productName;
            set
            {
                productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string reportPost;
        public string ReportPost
        {
            get => reportPost;
            set
            {
                reportPost = value;
                OnPropertyChanged(nameof(ReportPost));
            }
        }

        private string reason;
        public string Reason
        {
            get => reason;
            set
            {
                reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }

        private string experienceId;
        public string ExperienceId
        {
            get => experienceId;
            set
            {
                experienceId = value;
                OnPropertyChanged(nameof(ExperienceId));
            }
        }


        private string blockPost;
        public string BlockPost
        {
            get => blockPost;
            set
            {
                blockPost = value;
                OnPropertyChanged(nameof(BlockPost));
            }
        }

        private string mutePost;
        public string MutePost
        {
            get => mutePost;
            set
            {
                mutePost = value;
                OnPropertyChanged(nameof(MutePost));
            }
        }


        private string muteTitle;
        public string MuteTitle
        {
            get => muteTitle;
            set
            {
                muteTitle = value;
                OnPropertyChanged(nameof(MuteTitle));
            }
        }

        private string blockTitle;
        public string BlockTitle
        {
            get => blockTitle;
            set
            {
                blockTitle = value;
                OnPropertyChanged(nameof(BlockTitle));
            }
        }

        private string userId;
        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
        #endregion

        #region Commands
        public Command TappedCommand { get; }
        public Command SelectPageCommand { get; }
        public Command ReportPostCommand { get; }
        public Command BlockPostCommand { get; }
        public Command FlagPostCommand { get; }

        public ICommand ToggleDescriptionCommand => new Command<ExperienceData>(OpenPopup);

        private async void OpenPopup(ExperienceData experience)
        {

            await PopupNavigation.Instance.PushAsync(new ExperienceDetailPopup(SelectedItems));

        }

        //public ICommand ToggleDescriptionCommand => new Command<ExperienceData>(ToggleDescription);

        //private void ToggleDescription(ExperienceData scam)
        //{
        //    scam.IsExpanded = !scam.IsExpanded;
        //}
        #endregion


        #region functions, methods, events and Navigations

        private async Task GetTappedExecute()
        {
            try
            {
                //Device.BeginInvokeOnMainThread(async () => {
                //    await PopupNavigation.Instance.PopAsync();
                //    await Navigation.PushAsync(new ReportPostPage());
                //});

                await PopupNavigation.Instance.PopAsync(); // Close the popup first

                //await Navigation.PushAsync(new ReportPostPage());

                //await PopupNavigation.Instance.PushAsync(new ReportPostPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private async Task SelectPageCommandExecute()
        {

            List<SelectItemModel> reasonForReport = new List<SelectItemModel>()
            {
                new SelectItemModel(1,"Hate Speech"),
                new SelectItemModel(2,"Abuse and Harassment"),
                new SelectItemModel(3,"Violent Speech"),
                new SelectItemModel(4,"Child Safety"),
                new SelectItemModel(5,"Privacy"),
                new SelectItemModel(6,"Spam"),
                new SelectItemModel(7,"Suicide or self-harm"),
                new SelectItemModel(8,"Sensitive or disturbing media"),
                new SelectItemModel(9,"Violent & hateful entities"),

            };
            var popup = new SelectItemPickerPopup(reasonForReport);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            ReportPost = result.Item1;

        }


        private async Task ReportPostCommandExecute()
        {
            if (string.IsNullOrWhiteSpace(Reason))
            {
                await MessagePopup.Instance.Show("Reason for report field should not be empty");

                return;
            }

            try
            {

                await LoadingPopup.Instance.Show("Reporting post...");

                ReportPostRequestModel requestPayload = new ReportPostRequestModel() { experienceId = ExperienceId, reasonReportedBody = Reason, reasonReportedTitle = ReportPost };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.ReportPostAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Post reported successfully.");

                    await Navigation.PopAsync();

                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expire.");

                    Application.Current.MainPage = new NavigationPage(new Login());

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


        private async Task BlockPostCommandExecute()
        {
         
            try
            {

                await PopupNavigation.Instance.PopAsync(); // Close the popup first

                await LoadingPopup.Instance.Show("Blocking User...");

                BlockPostRequestModel requestPayload = new BlockPostRequestModel() { blockUserId = UserId };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.BlockPostAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("User blocked successfully.");

                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expire.");

                    Application.Current.MainPage = new NavigationPage(new Login());

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


        private async Task FlagPostCommandExecute()
        {

            try
            {

                await PopupNavigation.Instance.PopAsync(); // Close the popup first

                await LoadingPopup.Instance.Show("Flagging Post...");

                FlagPostRequestModel requestPayload = new FlagPostRequestModel() { experienceId = ExperienceId };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.FlagPostAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Post flagged successfully.");

                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expire.");

                    Application.Current.MainPage = new NavigationPage(new Login());

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
