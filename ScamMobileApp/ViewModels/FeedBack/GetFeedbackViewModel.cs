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
    public class GetExperienceViewModel : BaseViewModel
    {
        public GetExperienceViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _tsk = FetchFeedback();

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

        #endregion

        #region Commands
        #endregion


        #region functions, methods, events and Navigations
        private async Task FetchFeedback()
        {
            try
            {
                await LoadingPopup.Instance.Show("Loading Profile detail...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserFeedBackAsync();
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        FeedbackData = ResponseData.data;
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

        #endregion

    }

}
