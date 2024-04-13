using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Experience
{
    public class PostExperienceViewModel : BaseViewModel
    {
        public PostExperienceViewModel(INavigation navigation)
        {
            Navigation = navigation;


            PostExerienceCommand = new Command(async () => await PostExerienceCommandExecute(title, message));

            //LoginCommand = new Command(async () => await LoginCommandsExecute());
            SelectPageCommand = new Command(async () => await SelectPageCommandExecute());

        }

        #region Binding Properties

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

        private string othertitle;
        public string Othertitle
        {
            get => othertitle;
            set
            {
                othertitle = value;
                OnPropertyChanged(nameof(Othertitle));
            }
        }

        private bool scamCheck;
        public bool ScamCheck
        {
            get => scamCheck;
            set
            {
                scamCheck = value;
                OnPropertyChanged(nameof(ScamCheck));
            }
        }

        private bool others = false;
        public bool Others
        {
            get => others;
            set
            {
                others = value;
                OnPropertyChanged(nameof(Others));
            }
        }
        #endregion


        #region Events, Methods, Functions and Navigations
        public Command PostExerienceCommand { get; }
        public Command SelectPageCommand { get; }

        #endregion

        #region

        private async Task SelectPageCommandExecute()
        {

            List<SelectItemModel> scamsTypes = new List<SelectItemModel>()
            {
                new SelectItemModel(1,"PHISHING SCAM"),
                new SelectItemModel(2,"VISHING SCAM"),
                new SelectItemModel(3,"SMISHING SCAM"),
                new SelectItemModel(4,"INVESTMENT SCAM"),
                new SelectItemModel(5,"ROMANCE SCAM"),
                new SelectItemModel(6,"QR CODE SCAMS"),
                new SelectItemModel(7,"IMPERSONATION SCAM"),
                new SelectItemModel(8,"RANSOMWARE  SCAM"),
                new SelectItemModel(9,"ATM SKIMMING SCAM"),
                new SelectItemModel(10,"TECH SUPPORT SCAM"),
                new SelectItemModel(11,"BUSINESS EMAIL COMPROMISE(BEC) SCAM"),
                new SelectItemModel(12,"LOTTERY, PRIZE OR FREE GIFTS SCAM"),
                new SelectItemModel(13,"SOCIAL MEDIA  SCAM"),
                new SelectItemModel(14,"TAX SCAM"),
                new SelectItemModel(15,"IDENTITY THEFT SCAM"),
                new SelectItemModel(16,"GRANDPARENT OR PARENT SCAM"),
                new SelectItemModel(17,"CHARITY SCAM"),
                new SelectItemModel(18,"ONLINE SHOPPING SCAM"),
                new SelectItemModel(19,"EMPLOYMENT OPPORTUNITY SCAM"),
                new SelectItemModel(20,"FAKE INVOICE SCAM"),
                new SelectItemModel(21,"GIFT CARD SCAM"),
                new SelectItemModel(22,"Other SCAM"),

            };
            var popup = new SelectItemPickerPopup(scamsTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Title = result.Item1;

            if (Title == "Other SCAM")
            {
                Others = true;
            }
            else
            {
                Others = false;
            }
        }

        private async Task PostExerienceCommandExecute(string title, string message)
        {
            if (ScamCheck == true)
            {
                await PostExperienceAsync(title, message);
            }
            else
            {
                await MessagePopup.Instance.Show("Accept Terms and Conditions to continue.");

                return;
            }
        }


        private async Task PostExperienceAsync(string title, string message)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                await MessagePopup.Instance.Show("Your experience field should not be empty");
                return;
            }

            if (!string.IsNullOrWhiteSpace(Othertitle))
            {
                Title = Othertitle;
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                await MessagePopup.Instance.Show("Select a scam type to continue");
                return;
            }



            try
            {

                await LoadingPopup.Instance.Show("Sharing Experience...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.PostExperienceAsync(Title, Message);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Experience posted successfully");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());

                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Token expire");
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
