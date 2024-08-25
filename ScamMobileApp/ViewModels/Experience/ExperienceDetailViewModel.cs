
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Questions.ATM;
using ScamMobileApp.Views.Questions.Business;
using ScamMobileApp.Views.Questions.Charity;
using ScamMobileApp.Views.Questions.Employment;
using ScamMobileApp.Views.Questions.Fake;
using ScamMobileApp.Views.Questions.Giftcard;
using ScamMobileApp.Views.Questions.Grandparent;
using ScamMobileApp.Views.Questions.Identity;
using ScamMobileApp.Views.Questions.Impersonation;
using ScamMobileApp.Views.Questions.Investment;
using ScamMobileApp.Views.Questions.Lottery;
using ScamMobileApp.Views.Questions.Online;
using ScamMobileApp.Views.Questions.Phishing;
using ScamMobileApp.Views.Questions.QRcode;
using ScamMobileApp.Views.Questions.Ransomware;
using ScamMobileApp.Views.Questions.Romance;
using ScamMobileApp.Views.Questions.Smishing;
using ScamMobileApp.Views.Questions.SocialMedia;
using ScamMobileApp.Views.Questions.Tax;
using ScamMobileApp.Views.Questions.Tech;
using ScamMobileApp.Views.Questions.Vishing;
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


            FirstName = UserExperienceData.FirstOrDefault().userDetails.firstname;
            LastName = UserExperienceData.FirstOrDefault().userDetails.lastname;

            BlockUser = $"Block {FirstName + " " + LastName}";
            MuteUser = $"Mute {FirstName + " " + LastName}";


            TappedCommand = new Command(async () => await GetTappedExecute());

            SelectPageCommand = new Command(async () => await SelectPageCommandExecute());


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

        #endregion

        #region Commands
        public Command TappedCommand { get; }
        public Command SelectPageCommand { get; }

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


        #endregion


    }

}
