using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class TriviaQuestionDetailsViewModel : BaseViewModel
    {
        public TriviaQuestionDetailsViewModel(INavigation navigation, ObservableCollection<TriviaQuestionModel> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            QuestionData = new ObservableCollection<TriviaQuestionModel>(SelectedItems);

            Question = QuestionData.FirstOrDefault().Question;

            QuestionSubject = QuestionData.FirstOrDefault().Subject;
            QuestionAnswer = QuestionData.FirstOrDefault().Answer;

        }


        #region Bindings

        public ObservableCollection<TriviaQuestionModel> selectedItems;
        public ObservableCollection<TriviaQuestionModel> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<TriviaQuestionModel> questionData;
        public ObservableCollection<TriviaQuestionModel> QuestionData
        {
            get => questionData;
            set
            {
                questionData = value;
                OnPropertyChanged(nameof(QuestionData));
            }
        }

        private string questionSubject;
        public string QuestionSubject
        {
            get => questionSubject;
            set
            {
                questionSubject = value;
                OnPropertyChanged(nameof(QuestionSubject));
            }
        }

        private string question;
        public string Question
        {
            get => question;
            set
            {
                question = value;
                OnPropertyChanged(nameof(Question));
            }
        }

        private string questionAnswer;
        public string QuestionAnswer
        {
            get => questionAnswer;
            set
            {
                questionAnswer = value;
                OnPropertyChanged(nameof(QuestionAnswer));
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
