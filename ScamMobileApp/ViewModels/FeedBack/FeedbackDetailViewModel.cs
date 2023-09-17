using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.FeedBack
{
    public class FeedbackDetailViewModel : BaseViewModel
    {
        public FeedbackDetailViewModel(INavigation navigation, ObservableCollection<GetFeedbackData> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            UserFeedbackData = new ObservableCollection<GetFeedbackData>(SelectedItems);

            ScamType = UserFeedbackData.FirstOrDefault().scamType;

            QuestionData = UserFeedbackData.FirstOrDefault().questionAnswer;


        }


        #region Bindings

        public ObservableCollection<GetFeedbackData> selectedItems;
        public ObservableCollection<GetFeedbackData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<GetFeedbackData> userFeedbackData;
        public ObservableCollection<GetFeedbackData> UserFeedbackData
        {
            get => userFeedbackData;
            set
            {
                userFeedbackData = value;
                OnPropertyChanged(nameof(UserFeedbackData));
            }
        }
        private string scamType;
        public string ScamType
        {
            get => scamType;
            set
            {
                scamType = value;
                OnPropertyChanged(nameof(ScamType));
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

        #endregion

        #region Commands

        #endregion


        #region functions, methods, events and Navigations


        #endregion


    }

}
