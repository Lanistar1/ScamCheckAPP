using ScamMobileApp.Models.Identity;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ScamMobileApp.Models.Experience;
using System.Collections.ObjectModel;

namespace ScamMobileApp.ViewModels.Others
{

    public class KeywordViewModel : BaseViewModel
    {
        public KeywordViewModel(INavigation navigation)
        {
            Navigation = navigation;

            KeywordCommand = new Command(async () => await KeywordCommandExecute());

            AddKeywordCommand = new Command(async () => await ExecuteAddKeywordCommand());


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

        List<string> tagList = new List<string>();

        private string _tagInput;
        public string TagInput
        {
            get { return _tagInput; }
            set
            {
                if (_tagInput != value)
                {
                    _tagInput = value;
                    OnPropertyChanged(nameof(TagInput));
                }
            }
        }

        private KeywordData unwantedKeywords;
        public KeywordData UnwantedKeywords
        {
            get => unwantedKeywords;
            set
            {
                unwantedKeywords = value;
                OnPropertyChanged(nameof(UnwantedKeywords));
            }
        }

        private string emptyPlaceholder = "Fetching Unwanted Keywords...";
        public string EmptyPlaceholder
        {
            get => emptyPlaceholder;
            set
            {
                emptyPlaceholder = value;
                OnPropertyChanged(nameof(EmptyPlaceholder));
            }
        }
        #endregion


        #region Command
        public Command KeywordCommand { get; }
        public Command AddKeywordCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations

        private async Task ExecuteAddKeywordCommand()
        {
            if (!string.IsNullOrWhiteSpace(TagInput))
            {
                tagList.Add(TagInput);
                //string result = TagInput + " " + "added";

                var message = TagInput + " " + "added to unwanted Keywords";
                await MessagePopup.Instance.Show(message);

                TagInput = string.Empty; // Clear the input field
            }
        }

        private async Task KeywordCommandExecute()
        {
            //if (string.IsNullOrWhiteSpace(Message))
            //{
            //    await MessagePopup.Instance.Show("Message field should not be empty");

            //    return;
            //}

            try
            {

                await LoadingPopup.Instance.Show("Adding unwanted keywords...");

                KeywordsRequestModel requestPayload = new KeywordsRequestModel() { keyword = tagList };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.AddUnwantedkeywordsAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Unwanted keywords added successfully.");

                    //Application.Current.MainPage = new NavigationPage(new Tabbed());
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

        private async Task FetchUnwantedKeywords()
        {
            try
            {
                await LoadingPopup.Instance.Show("Fetching Keywords...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUnwantedKeywordsAsync();
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        UnwantedKeywords = ResponseData.data;

                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                        EmptyPlaceholder = "No Keyword found.";

                    }
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    string message = "Error fetching unwanted keywords. Do you want to RETRY?";
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
                string message = "Something went wrong. Try again later. ";
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
