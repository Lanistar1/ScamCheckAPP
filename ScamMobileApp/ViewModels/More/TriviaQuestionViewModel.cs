using Newtonsoft.Json;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Popup;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class TriviaQuestionViewModel : BaseViewModel
    {

        public TriviaQuestionViewModel(INavigation navigation)
        {
            Navigation = navigation;

            TappedCommand = new Command<TriviaQuestionModel>(async (model) => await GetTappedExecute(model));

            Task _tsk = FetchTriviaQuestion();

            //QuestionAndAnswer = new ObservableCollection<TriviaQuestionModel>
            //{
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },
            //    new TriviaQuestionModel { ID= 111701, Subject= "Serious Symbols", Question= "What symbol reminiscent of pirates indicates a poisonous substance?",Answer= "skull and crossbones", Metadata= "health pirate poison science symbol toxicology" },

            //};

            Questions = new ObservableCollection<TriviaQuestionModel>
            {
                new TriviaQuestionModel
                {
                    ID = 55422,
                    Subject = "Gruesome Executions",
                    Question = "This is about the execution of what 13th century Scottish hero?...",
                    Answer = "William Wallace",
                    Metadata = "13th century hero history Scotland",
                    options = new ObservableCollection<string> { "William Wallace", "Andrew Moray", "Robert the Bruce", "James Douglas" }
                },
                new TriviaQuestionModel
                {
                    ID = 55423,
                    Subject = "Historical Discoveries",
                    Question = "Who is credited with discovering America in 1492, although the land was already inhabited by indigenous peoples?",
                    Answer = "Christopher Columbus",
                    Metadata = "exploration discovery America history world history",
                    options = new ObservableCollection<string> {  "Christopher Columbus", "Ferdinand Magellan", "Leif Erikson", "Amerigo Vespucci" }
                },
                new TriviaQuestionModel
                {
                    ID = 55424,
                    Subject = "World War II",
                    Question = "What city was the first to be targeted with an atomic bomb during World War II?",
                    Answer = "Hiroshima",
                    Metadata = "World War II history Japan nuclear warfare",
                    options = new ObservableCollection<string> { "Nagasaki", "Tokyo", "Hiroshima", "Kyoto" }
                },
                new TriviaQuestionModel
                {
                    ID = 55425,
                    Subject = "Gruesome Executions",
                    Question = "This is about the execution of what 13th century Scottish hero?...",
                    Answer = "William Wallace",
                    Metadata = "13th century hero history Scotland",
                    options = new ObservableCollection<string> { "William Wallace", "Andrew Moray", "Robert the Bruce", "James Douglas" }
                },
                // Add the other questions similarly...
            };

            _currentQuestionIndex = 0;
            CurrentQuestion = Questions[_currentQuestionIndex];

            NextQuestionCommand = new Command(NextQuestion, () => IsAnswerSelected);
            IsAnswerSelected = false;

        }

        private void NextQuestion()
        {
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                CurrentQuestion = Questions[_currentQuestionIndex];
                IsAnswerSelected = false;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
            else
            {
                // Quiz finished - handle this (e.g., navigate to a summary page)
                Application.Current.MainPage.DisplayAlert("Quiz Complete", "You've completed the quiz!", "OK");
            }

            IsAnswerSelected = false;
        }

        public void OnOptionSelected(string selectedOption)
        {

            IsAnswerSelected = true;
            if (selectedOption == CurrentQuestion.Answer)
            {
                Application.Current.MainPage.DisplayAlert("Correct!", "You answered correctly!", "Next");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Incorrect", $"The correct answer is: {CurrentQuestion.Answer}", "Next");
            }

             //((Command)NextQuestionCommand).ChangeCanExecute();

        }

        private int _currentQuestionIndex;

        public ObservableCollection<TriviaQuestionModel> Questions { get; set; }
        public TriviaQuestionModel CurrentQuestion { get; set; }

        private bool _isAnswerSelected;
        public bool IsAnswerSelected
        {
            get => _isAnswerSelected;
            set
            {
                _isAnswerSelected = value;
                OnPropertyChanged(nameof(IsAnswerSelected));
            }
        }

        public ICommand NextQuestionCommand { get; set; }

        #region Bindings
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

        //private TriviaQuestionModel questions;
        //public TriviaQuestionModel Questions
        //{
        //    get => questions;
        //    set
        //    {
        //        questions = value;
        //        OnPropertyChanged(nameof(Questions));
        //    }
        //}

        public ObservableCollection<TriviaQuestionModel> QuestionAndAnswer { get; set; }

        private ObservableCollection<TriviaQuestionModel> SelectedItems = new ObservableCollection<TriviaQuestionModel>();

        #endregion

        #region Commands
        public Command TappedCommand { get; }

        #endregion

        private async Task GetTappedExecute(TriviaQuestionModel model)
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

                await Navigation.PushAsync(new TriviaQuestionDetailPage(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task FetchTriviaQuestion()
        {
            try
            {

                await LoadingPopup.Instance.Show("Fetching Questions...");

                HttpClient client = new HttpClient();

                string url = "https://zylalabs.com/api/1992/trivia+questions+api/1758/get+random+questions";

                // Add the API key in the Authorization header
                client.DefaultRequestHeaders.Add("Authorization", "Bearer aae4b3c2c26042a9b4d5ad99afafe4c5");


                HttpResponseMessage response = await client.GetAsync(url);

                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<TriviaQuestionModel>(result);
                    Console.WriteLine("passedjiojiojiojio");

                    var latestQuestions = data;
                    //Questions = latestQuestions;
                    Console.WriteLine("vdhvg hdsh");
                }

                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }
    }

}
