using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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
        public Command TappedCommand { get; }

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
            new VideoModel { Title = "SCAMalicious", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731676437/SCAMalicious_1_ltz4j0.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731676437/SCAMalicious_1_ltz4j0.jpg" },
            new VideoModel { Title = "What is SCAMalicious? Here's Everything you need to know!", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731677647/What_is_SCAMalicious__Here_s_Everything_You_Need_to_Know_-_Play_Store_piwe2s.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731677647/What_is_SCAMalicious__Here_s_Everything_You_Need_to_Know_-_Play_Store_piwe2s.jpg" },
            new VideoModel { Title = "How SCAMalicious Helps You Spot and Stop Scams-Feature & Benefits!", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948525/How_SCAMalicious_Helps_You_Spot_and_Stop_Scams_Features_Benefits_-_Play_Store_cvheso.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948525/How_SCAMalicious_Helps_You_Spot_and_Stop_Scams_Features_Benefits_-_Play_Store_cvheso.jpg" },
            new VideoModel { Title = "Scam Q&A Feature of SCAMalicious", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948299/Scam_Q_A_Feature_of_SCAMalicious_-_Play_Store_rlspya.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948299/Scam_Q_A_Feature_of_SCAMalicious_-_Play_Store_rlspya.jpg" },
            new VideoModel { Title = "Type of Scam - Spot the Red Flags: Common Scams You Need to Know About!", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1732650907/Types_of_scams_-_Spot_the_Red_Flags__Common_Scams_You_Need_to_Know_About_-_Play_Store_1_kuqch0.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1732650907/Types_of_scams_-_Spot_the_Red_Flags__Common_Scams_You_Need_to_Know_About_-_Play_Store_1_kuqch0.jpg" },
            new VideoModel { Title = "Types of Website Scams - Watch out for Red Flags", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948938/Types_of_Website_Scams_-_Watch_out_for_Red_Flags_-_Play_Store_tg0sxt.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731948938/Types_of_Website_Scams_-_Watch_out_for_Red_Flags_-_Play_Store_tg0sxt.jpg" },
            new VideoModel { Title = "Spot the Red Flags of AI Scams", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949054/Spot_Red_Flags_of_AI_Scams_-_Play_Store.mp4_r9mrnr.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949054/Spot_Red_Flags_of_AI_Scams_-_Play_Store.mp4_r9mrnr.jpg" },
            new VideoModel { Title = "Scam Alert Series News - Assam Million dollar Fraud", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1732044908/Scam_Alert_Series__News_-_Assam_Million_dollar_Fraud_1_2_1_gdxwgg.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1732044908/Scam_Alert_Series__News_-_Assam_Million_dollar_Fraud_1_2_1_gdxwgg.jpg" },
            new VideoModel { Title = "Scam Alert Series Credit Card Identity Theft", VideoUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949423/Scam_Alert_Series__Credit_Card_Identity_Theft_1_shhqck.mp4", ThumbnailUrl = "https://res.cloudinary.com/djugoq0eb/video/upload/v1731949423/Scam_Alert_Series__Credit_Card_Identity_Theft_1_shhqck.jpg" },
            };

            PlayVideoCommand = new Command<VideoModel>(OnPlayVideo);

            TappedCommand = new Command<VideoModel>(async (model) => await GetTappedExecute(model));

        }

        private void OnPlayVideo(VideoModel video)
        {
            SelectedVideoUrl = video.VideoUrl;
        }

        private ObservableCollection<VideoModel> SelectedItems = new ObservableCollection<VideoModel>();


        private async Task GetTappedExecute(VideoModel model)
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

    }
}
