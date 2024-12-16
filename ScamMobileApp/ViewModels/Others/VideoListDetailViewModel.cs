using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{

    public class VideoListDetailViewModel : BaseViewModel
    {
        public VideoListDetailViewModel(INavigation navigation, ObservableCollection<VideoModel> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            VideoData = new ObservableCollection<VideoModel>(SelectedItems);

            VideoTitle = VideoData.FirstOrDefault().Title;

            SelectedVideoUrl = VideoData.FirstOrDefault().VideoUrl;

        }


        #region Bindings

        public ObservableCollection<VideoModel> selectedItems;
        public ObservableCollection<VideoModel> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<VideoModel> videoData;
        public ObservableCollection<VideoModel> VideoData
        {
            get => videoData;
            set
            {
                videoData = value;
                OnPropertyChanged(nameof(VideoData));
            }
        }
        private string videoTitle;
        public string VideoTitle
        {
            get => videoTitle;
            set
            {
                videoTitle = value;
                OnPropertyChanged(nameof(VideoTitle));
            }
        }

        private List<QuestionAnswer> questionData;
        public List<QuestionAnswer> QuestionData
        {
            get => questionData;
            set
            {
                questionData = value;
                OnPropertyChanged(nameof(QuestionData));
            }
        }

        private string _selectedVideoUrl;
        public string SelectedVideoUrl
        {
            get => _selectedVideoUrl;
            set
            {
                _selectedVideoUrl = value;
                OnPropertyChanged();
            }
        }

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        #endregion

        #region Commands

        #endregion


        #region functions, methods, events and Navigations


        #endregion


    }

}
