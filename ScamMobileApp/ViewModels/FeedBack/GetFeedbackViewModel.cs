using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

            TappedCommand = new Command<GetFeedbackData>(async (model) => await GetTappedExecute(model));

        }


        #region Bindings
        private ObservableCollection<GetFeedbackData> SelectedItems = new ObservableCollection<GetFeedbackData>();


        private ObservableCollection<GetFeedbackData> feedbackData;
        public ObservableCollection<GetFeedbackData> FeedbackData
        {
            get => feedbackData;
            set
            {
                feedbackData = value;
                OnPropertyChanged(nameof(FeedbackData));
            }
        }

        private ObservableCollection<GetFeedbackData> newFeedbackData;
        public ObservableCollection<GetFeedbackData> NewFeedbackData
        {
            get => newFeedbackData;
            set
            {
                newFeedbackData = value;
                OnPropertyChanged(nameof(NewFeedbackData));
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

        private string searchEntry = string.Empty;
        private CancellationTokenSource searchDelayTokenSource;
        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;

                // Cancel the previous search delay task if it exists
                searchDelayTokenSource?.Cancel();

                // Create a new cancellation token source
                searchDelayTokenSource = new CancellationTokenSource();

                // Delay the execution of the command to allow the value to update
                Task.Delay(TimeSpan.FromMilliseconds(200), searchDelayTokenSource.Token)
                    .ContinueWith(_ =>
                    {
                        if (!searchDelayTokenSource.Token.IsCancellationRequested)
                        {
                            SearchEntryTextChangedCommand.Execute(searchEntry);
                        }
                    });

                OnPropertyChanged(nameof(SearchEntry));
            }
        }
        #endregion

        #region Commands
        public Command TappedCommand { get; }
        public Command SearchEntryTextChangedCommand => new Command<string>((searchEntry) => SearchBar_TextChanged(searchEntry));
        public Command SearchCommand { get; }

        #endregion


        #region functions, methods, events and Navigations

        private async Task GetTappedExecute(GetFeedbackData model)
        {
            try
            {
                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (SelectedItems.Count > 0)
                {
                    SelectedItems.Clear();
                }
                SelectedItems.Add(model);

                await Navigation.PushAsync(new FeedbackDetailPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


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
                        if(ResponseData.data.Count > 0)
                        {
                            NewFeedbackData = ResponseData.data;
                            FeedbackData = NewFeedbackData;
                        }
                        else
                        {
                            EmptyPlaceholder = "No Feedback found.";
                        }

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


        private void SearchBar_TextChanged(string _searchEntry)
        {
            try
            {
                if (_searchEntry.Length >= 1 && FeedbackData.Count() >= 1)
                {
                    var _newList = NewFeedbackData.Where(x => x.scamType.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                    if (_newList.Count() <= 0)
                    {
                        FeedbackData = new ObservableCollection<GetFeedbackData>(_newList);
                        EmptyPlaceholder = "No Scam type found";
                    }
                    else if (_newList.Count() > 0)
                    {
                        FeedbackData = new ObservableCollection<GetFeedbackData>(_newList);
                    }
                    else
                    {
                        FeedbackData = new ObservableCollection<GetFeedbackData>(NewFeedbackData);
                    }

                }
                else if (NewFeedbackData != null)
                {
                    FeedbackData = null;
                    FeedbackData = new ObservableCollection<GetFeedbackData>(NewFeedbackData);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        #endregion

    }

}
