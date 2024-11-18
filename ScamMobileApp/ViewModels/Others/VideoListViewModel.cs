using ScamMobileApp.Models.Others;
using ScamMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{

    public class VideoListViewModel : BaseViewModel
    {
        private string _selectedVideoUrl;

        public ObservableCollection<VideoModel> Videos { get; set; }

        public string SelectedVideoUrl
        {
            get => _selectedVideoUrl;
            set
            {
                _selectedVideoUrl = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlayVideoCommand { get; }

        public VideoListViewModel(INavigation navigation)
        {
            Navigation = navigation;

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                MessagePopup.Instance.Show("Internet connection not available");
                return;
            }

            Videos = new ObservableCollection<VideoModel>
            {
            new VideoModel { Title = "Video 1", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731676437/SCAMalicious_1_ltz4j0.mp4" },
            new VideoModel { Title = "Video 2", VideoUrl = "https://yourvideo5.mp4" },
            new VideoModel { Title = "Video 3", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948525/How_SCAMalicious_Helps_You_Spot_and_Stop_Scams_Features_Benefits_-_Play_Store_cvheso.mp4" },
            new VideoModel { Title = "Video 4", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948299/Scam_Q_A_Feature_of_SCAMalicious_-_Play_Store_rlspya.mp4" },
            new VideoModel { Title = "Video 5", VideoUrl = "https://yourvideo5.mp4" },
            new VideoModel { Title = "Video 6", VideoUrl = "https://yourvideo6.mp4" },
            new VideoModel { Title = "Video 7", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949054/Spot_Red_Flags_of_AI_Scams_-_Play_Store.mp4_r9mrnr.mp4" },
            new VideoModel { Title = "Video 8", VideoUrl = "https://yourvideo6.mp4" },
            new VideoModel { Title = "Video 8", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949423/Scam_Alert_Series__Credit_Card_Identity_Theft_1_shhqck.mp4" },
            };

            PlayVideoCommand = new Command<VideoModel>(OnPlayVideo);
        }

        private void OnPlayVideo(VideoModel video)
        {
            SelectedVideoUrl = video.VideoUrl;
        }
    }
}
