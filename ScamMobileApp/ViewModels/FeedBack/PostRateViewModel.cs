using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.FeedBack
{
    public class PostRateViewModel : BaseViewModel
    {
        public PostRateViewModel(INavigation navigation)
        {
            Navigation = navigation;

            AppRatingCommand = new Command(async () => await AppRatingCommandExecute());

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

        private string myComment;
        public string MyComment
        {
            get => myComment;
            set
            {
                myComment = value;
                OnPropertyChanged(nameof(MyComment));
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
        #endregion


        #region Command
        public Command AppRatingCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations

        private async Task AppRatingCommandExecute()
        {

            try
            {

                await LoadingPopup.Instance.Show("Posting app rating...");

                var ratingNumber = Global.newRatingNumber;
                Global.comment = MyComment;


                PostRateRequestModel requestPayload = new PostRateRequestModel() { rating = ratingNumber };

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.AddRatingAsync(requestPayload);

                if (ResponseData != null)
                {
                    await MessagePopup.Instance.Show("Rating Created successfully.");

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
