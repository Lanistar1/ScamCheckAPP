using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
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
    public class GetFeedbackViewModel : BaseViewModel
    {
        public GetFeedbackViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = FetchFeedback(limit, offset);

        }


        #region Bindings

        private List<GetFeedbackData> feedbackData;
        public List<GetFeedbackData> FeedbackData
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

        private string offset;
        public string Offset
        {
            get => offset;
            set
            {
                offset = value;
                OnPropertyChanged(nameof(Offset));
            }
        }

        private string limit;
        public string Limit
        {
            get => limit;
            set
            {
                limit = value;
                OnPropertyChanged(nameof(Limit));
            }
        }
        #endregion

        #region Commands
        #endregion


        #region functions, methods, events and Navigations
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
                        FeedbackData = ResponseData.data;
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
