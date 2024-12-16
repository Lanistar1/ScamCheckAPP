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

            Task _tsk = FetchUnwantedKeywords();

            KeywordCommand = new Command(async () => await KeywordCommandExecute());

            AddKeywordCommand = new Command(async () => await ExecuteAddKeywordCommand());

            CancelCommand = new Command<string>(async (keyword) => await ExecuteCancelCommand(keyword));

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

        private List<string> unwantedKeywords;
        public List<string> UnwantedKeywords
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
        public Command<string> CancelCommand { get; }

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


        //=======add unwanted keyword ==========
        private async Task KeywordCommandExecute()
        {
            try
            {
                // Merge the existing unwanted keywords with the new keywords
                var allKeywords = new List<string>();

                // Add previously fetched unwanted keywords
                if (UnwantedKeywords != null && UnwantedKeywords.Count > 0)
                {
                    allKeywords.AddRange(UnwantedKeywords);
                }

                // Add new keywords added by the user
                if (tagList != null && tagList.Count > 0)
                {
                    allKeywords.AddRange(tagList);
                }

                await LoadingPopup.Instance.Show("Adding unwanted keywords...");

                KeywordsRequestModel requestPayload = new KeywordsRequestModel() { keyword = allKeywords };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.AddUnwantedkeywordsAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Unwanted keywords added successfully.");

                    // Fetch the updated list of unwanted keywords to display
                    await FetchUnwantedKeywords();
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expired.");
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


        // =============remove keyword ==============
        private async Task ExecuteCancelCommand(string keywordToRemove)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keywordToRemove))
                    return;

                // Filter out the keyword to remove
                var remainingKeywords = new List<string>(UnwantedKeywords);
                remainingKeywords.Remove(keywordToRemove);

                await LoadingPopup.Instance.Show("Updating unwanted keywords...");

                KeywordsRequestModel requestPayload = new KeywordsRequestModel() { keyword = remainingKeywords };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.AddUnwantedkeywordsAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show($"Keyword '{keywordToRemove}' removed successfully.");

                    // Fetch the updated keywords
                    await FetchUnwantedKeywords();
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    await MessagePopup.Instance.Show("Session expired.");
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


        //private async Task KeywordCommandExecute()
        //{

        //    try
        //    {

        //        await LoadingPopup.Instance.Show("Adding unwanted keywords...");

        //        KeywordsRequestModel requestPayload = new KeywordsRequestModel() { keyword = tagList };

        //        var (ResponseData, ErrorData, StatusCode) = await _scamAppService.AddUnwantedkeywordsAsync(requestPayload);

        //        if (ResponseData != null)
        //        {
        //            await MessagePopup.Instance.Show("Unwanted keywords added successfully.");

        //            //Application.Current.MainPage = new NavigationPage(new Tabbed());
        //        }

        //        else if (ErrorData != null && StatusCode == 401)
        //        {
        //            await MessagePopup.Instance.Show("Session expire.");

        //            Application.Current.MainPage = new NavigationPage(new Login());

        //        }
        //        else
        //        {
        //            await MessagePopup.Instance.Show(ErrorData.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        await MessagePopup.Instance.Show("Something went wrong. Please try again later.");
        //    }
        //    finally
        //    {
        //        await LoadingPopup.Instance.Hide();
        //    }
        //}

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
                        //UnwantedKeywords = ResponseData.data.keyword;

                        if (ResponseData.data.keyword.Count >= 0)
                        {
                            //await MessagePopup.Instance.Show(ErrorData.message);
                            //EmptyPlaceholder = "No Keyword found.";
                            UnwantedKeywords = ResponseData.data.keyword;

                            EmptyPlaceholder = "";


                        }
                        if (ResponseData.data.keyword.Count == 0)
                        {
                            EmptyPlaceholder = "No Keyword found.";
                        }

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
