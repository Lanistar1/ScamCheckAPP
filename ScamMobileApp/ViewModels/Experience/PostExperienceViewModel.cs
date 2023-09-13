using ScamMobileApp.Helpers;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views;
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
        #endregion


        #region Events, Methods, Functions and Navigations
        public Command PostExerienceCommand { get; }
        #endregion

        #region
        private async Task PostExerienceCommandExecute(string title, string message)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                await MessagePopup.Instance.Show("Message field should not be empty");
                return;
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                await MessagePopup.Instance.Show("Title field should not be empty");
                return;
            }

            try
            {

                await LoadingPopup.Instance.Show("Logging In...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.PostExperienceAsync(Title, Message);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Experience posted successfully");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());
                }

                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Token expire");
                    Application.Current.MainPage = new NavigationPage(new Tabbed());

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
