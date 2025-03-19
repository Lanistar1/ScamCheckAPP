using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{

    public class VideoListViewModel : BaseViewModel
    {

        #region Bindings
        private string _selectedVideoUrl;

        //public ObservableCollection<VideoData> Videos { get; set; }
        public ObservableCollection<VideoData> Videos { get; set; } = new ObservableCollection<VideoData>();


        public string SelectedVideoUrl
        {
            get => _selectedVideoUrl;
            set
            {
                _selectedVideoUrl = value;
                OnPropertyChanged();
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


        #region command
        public ICommand PlayVideoCommand { get; }
        public Command TappedCommand { get; }
        #endregion



        public VideoListViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Videos = new ObservableCollection<VideoData>();

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                MessagePopup.Instance.Show("Internet connection not available");
                return;
            }

            Task _tsk = FetchVideo();

            PlayVideoCommand = new Command<VideoData>(OnPlayVideo);

            TappedCommand = new Command<VideoData>(async (model) => await GetTappedExecute(model));

        }

        private void OnPlayVideo(VideoData video)
        {
            SelectedVideoUrl = video.url;
        }

        private ObservableCollection<VideoData> SelectedItems = new ObservableCollection<VideoData>();


        private async Task GetTappedExecute(VideoData model)
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

                await Navigation.PushAsync(new VideoDetailPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        private async Task FetchVideo()
        {
            try
            {
                await LoadingPopup.Instance.Show("Fetching Videos...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetVideosAsync();
                if (ResponseData != null)
                {

                    //if (ResponseData.data != null)
                    //{
                    //    // Generate thumbnails for each video
                    //    foreach (var video in ResponseData.data)
                    //    {
                    //        video.thumbnailUrl = GenerateThumbnailUrl(video.url);
                    //    }

                    //    // Assign the modified list with thumbnails
                    //    Videos = new ObservableCollection<VideoData>(ResponseData.data);
                    //}
                    if (ResponseData != null && ResponseData.data != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Videos.Clear();
                            foreach (var video in ResponseData.data)
                            {
                                video.thumbnailUrl = GenerateThumbnailUrl(video.url);
                                Videos.Add(video);
                            }
                        });
                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                        EmptyPlaceholder = "No Video found.";

                    }
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    string message = "Error fetching Videos. Try again later.";
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


        private string GenerateThumbnailUrl(string videoUrl)
        {
            if (string.IsNullOrEmpty(videoUrl))
                return null;

            string thumbnailUrl = videoUrl.Replace("/upload/", "/upload/w_300,h_200,c_fill,so_2/").Replace(".mp4", ".jpg");

            Console.WriteLine($"Generated Thumbnail URL: {thumbnailUrl}"); 
            return thumbnailUrl;
        }



    }
}
