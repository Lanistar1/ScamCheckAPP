﻿using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Models.ScamType;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Experience
{

    public class GetExperienceViewModel : BaseViewModel
    {
        public GetExperienceViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _tsk = FetchExperience();

            TappedCommand = new Command<ExperienceData>(async (model) => await GetTappedExecute(model));


        }


        #region Bindings

        private ObservableCollection<ExperienceData> SelectedItems = new ObservableCollection<ExperienceData>();


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


        private string emptyPlaceholder = "Fetching Experiences...";
        public string EmptyPlaceholder
        {
            get => emptyPlaceholder;
            set
            {
                emptyPlaceholder = value;
                OnPropertyChanged(nameof(EmptyPlaceholder));
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

        private ObservableCollection<ExperienceData> newExperienceData;
        public ObservableCollection<ExperienceData> NewExperienceData
        {
            get => newExperienceData;
            set
            {
                newExperienceData = value;
                OnPropertyChanged(nameof(NewExperienceData));
            }
        }
        #endregion

        #region Commands
        public Command SearchEntryTextChangedCommand => new Command<string>((searchEntry) => SearchBar_TextChanged(searchEntry));
        public Command SearchCommand { get; }
        public Command TappedCommand { get; }
        #endregion


        #region functions, methods, events and Navigations

        private async Task GetTappedExecute(ExperienceData model)
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

                await Navigation.PushAsync(new ExperienceDetailPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        private async Task FetchExperience()
        {
            try
            {
                await LoadingPopup.Instance.Show("Fetching Experience...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetUserExperienceAsync();
                if (ResponseData != null)
                {
                    if (ResponseData.data != null)
                    {
                        UserExperienceData = ResponseData.data;

                        NewExperienceData = UserExperienceData;

                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                        EmptyPlaceholder = "No Experience found.";

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
                if (_searchEntry.Length >= 1 && NewExperienceData.Count() >= 1)
                {
                    var _newList = UserExperienceData.Where(x => x.title.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                    if (_newList.Count() <= 0)
                    {
                        NewExperienceData = new ObservableCollection<ExperienceData>(_newList);
                        EmptyPlaceholder = "No Scam type found";
                    }
                    else if (_newList.Count() > 0)
                    {
                        NewExperienceData = new ObservableCollection<ExperienceData>(_newList);
                    }
                    else
                    {
                        NewExperienceData = new ObservableCollection<ExperienceData>(UserExperienceData);
                    }

                }
                else if (UserExperienceData != null)
                {
                    NewExperienceData = null;
                    NewExperienceData = new ObservableCollection<ExperienceData>(UserExperienceData);
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