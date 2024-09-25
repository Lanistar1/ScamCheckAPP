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

namespace ScamMobileApp.ViewModels.Others
{

    public class KeywordViewModel : BaseViewModel
    {
        public KeywordViewModel(INavigation navigation)
        {
            Navigation = navigation;

            KeywordCommand = new Command(async () => await KeywordCommandExecute());

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

        #endregion


        #region Command
        public Command KeywordCommand { get; }
        #endregion

        #region Events, Methods, Functions and Navigations

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

                KeywordsRequestModel requestPayload = new KeywordsRequestModel() {};

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


        #endregion
    }

}
