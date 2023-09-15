using Newtonsoft.Json;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views;
using ScamMobileApp.Views.Questions;
using ScamMobileApp.Views.Questions.Employment;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.ScamCalculator
{
    public class EmploymentViewModel : BaseViewModel
    {
        public EmploymentViewModel(INavigation navigation)
        {
            Navigation = navigation;
            PostFeedbackCommand = new Command(async () => await PostFeedbackCommandExecute());

            ScamCalculatorCommand = new Command(async () => await ScamCalculatorCommandExecute());
            FirstQuestionCommand = new Command(async () => await FirstQuestionCommandExecute());
            SecondQuestionCommand = new Command(async () => await SecondQuestionCommandExecute());
            ThirdQuestionCommand = new Command(async () => await ThirdQuestionCommandExecute());

        }

        #region Bindings
        private bool questionOneCheckYes;
        public bool QuestionOneCheckYes
        {
            get => questionOneCheckYes;
            set
            {
                questionOneCheckYes = value;
                OnPropertyChanged(nameof(QuestionOneCheckYes));
            }
        }

        private bool questionOneCheckNo;
        public bool QuestionOneCheckNo
        {
            get => questionOneCheckNo;
            set
            {
                questionOneCheckNo = value;
                OnPropertyChanged(nameof(QuestionOneCheckNo));
            }
        }

        private bool questionTwoCheckYes;
        public bool QuestionTwoCheckYes
        {
            get => questionTwoCheckYes;
            set
            {
                questionTwoCheckYes = value;
                OnPropertyChanged(nameof(QuestionTwoCheckYes));
            }
        }

        private bool questionTwoCheckNo;
        public bool QuestionTwoCheckNo
        {
            get => questionTwoCheckNo;
            set
            {
                questionTwoCheckNo = value;
                OnPropertyChanged(nameof(QuestionTwoCheckNo));
            }
        }

        private bool questionThreeCheckYes;
        public bool QuestionThreeCheckYes
        {
            get => questionThreeCheckYes;
            set
            {
                questionThreeCheckYes = value;
                OnPropertyChanged(nameof(QuestionThreeCheckYes));
            }
        }

        private bool questionThreeCheckNo;
        public bool QuestionThreeCheckNo
        {
            get => questionThreeCheckNo;
            set
            {
                questionThreeCheckNo = value;
                OnPropertyChanged(nameof(QuestionThreeCheckNo));
            }
        }

        private bool questionFourCheckYes;
        public bool QuestionFourCheckYes
        {
            get => questionFourCheckYes;
            set
            {
                questionFourCheckYes = value;
                OnPropertyChanged(nameof(QuestionFourCheckYes));
            }
        }

        private bool questionFourCheckNo;
        public bool QuestionFourCheckNo
        {
            get => questionFourCheckNo;
            set
            {
                questionFourCheckNo = value;
                OnPropertyChanged(nameof(QuestionFourCheckNo));
            }
        }


        private string test1;
        public string Test1
        {
            get => test1;
            set
            {
                test1 = value;
                OnPropertyChanged(nameof(Test1));
            }
        }

        private string test2;
        public string Test2
        {
            get => test2;
            set
            {
                test2 = value;
                OnPropertyChanged(nameof(Test2));
            }
        }

        private string test3;
        public string Test3
        {
            get => test3;
            set
            {
                test3 = value;
                OnPropertyChanged(nameof(Test3));
            }
        }

        private string test4;
        public string Test4
        {
            get => test4;
            set
            {
                test4 = value;
                OnPropertyChanged(nameof(Test4));
            }
        }

        private string result1;
        public string Result1
        {
            get => result1;
            set
            {
                result1 = value;
                OnPropertyChanged(nameof(Result1));
            }
        }

        private string result2;
        public string Result2
        {
            get => result2;
            set
            {
                result2 = value;
                OnPropertyChanged(nameof(Result2));
            }
        }

        private string result3;
        public string Result3
        {
            get => result3;
            set
            {
                result3 = value;
                OnPropertyChanged(nameof(Result3));
            }
        }

        private string result4;
        public string Result4
        {
            get => result4;
            set
            {
                result4 = value;
                OnPropertyChanged(nameof(Result4));
            }
        }


        private string scamResult;
        public string ScamResult
        {
            get => scamResult;
            set
            {
                scamResult = value;
                OnPropertyChanged(nameof(ScamResult));
            }
        }

        private string likelyOrNot;
        public string LikelyOrNot
        {
            get => likelyOrNot;
            set
            {
                likelyOrNot = value;
                OnPropertyChanged(nameof(LikelyOrNot));
            }
        }

        private string comment;
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        #endregion

        #region Commands
        public ICommand ScamCalculatorCommand { get; }
        public ICommand FirstQuestionCommand { get; }
        public ICommand SecondQuestionCommand { get; }
        public ICommand ThirdQuestionCommand { get; }
        public ICommand PostFeedbackCommand { get; }


        #endregion

        #region functions, methods, events and Navigations

        private async Task FirstQuestionCommandExecute()
        {
            if (QuestionOneCheckYes == true && QuestionOneCheckNo == false)
            {
                Test1 = "25";
                Result1 = "YES";

            }
            else if (QuestionOneCheckYes == false && QuestionOneCheckNo == true)
            {
                Test1 = "0";
                Result1 = "NO";

            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 1 to proceed");
                return;
            }
            int new1 = int.Parse(Test1);

            Global.firstTest = new1;
            Global.newResult1 = Result1;

            await Navigation.PushAsync(new EmploymentSecondQuestion());

        }

        private async Task SecondQuestionCommandExecute()
        {

            if (QuestionTwoCheckYes == true && QuestionTwoCheckNo == false)
            {
                Test2 = "25";
                Result2 = "YES";

            }
            else if (QuestionTwoCheckYes == false && QuestionTwoCheckNo == true)
            {
                Test2 = "0";
                Result2 = "NO";

            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 2 to proceed");
                return;
            }

            int new2 = int.Parse(Test2);

            Global.seconTest = new2;
            Global.newResult2 = Result2;

            await Navigation.PushAsync(new EmploymentThirdQuestion());

        }

        private async Task ThirdQuestionCommandExecute()
        {

            if (QuestionThreeCheckYes == true && QuestionThreeCheckNo == false)
            {
                Test3 = "25";
                Result3 = "YES";

            }
            else if (QuestionThreeCheckYes == false && QuestionThreeCheckNo == true)
            {
                Test3 = "0";
                Result3 = "NO";

            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 3 to proceed");
                return;
            }
            int new3 = int.Parse(Test3);

            Global.thirdTest = new3;
            Global.newResult3 = Result3;

            await Navigation.PushAsync(new EmploymentFourthQuestion());

        }




        private async Task ScamCalculatorCommandExecute()
        {
            try
            {


                if (QuestionFourCheckYes == true && QuestionFourCheckNo == false)
                {
                    Test4 = "25";
                }
                else if (QuestionFourCheckYes == false && QuestionFourCheckNo == true)
                {
                    Test4 = "0";
                }
                else
                {
                    await MessagePopup.Instance.Show("Please answer question 4 to proceed");
                    return;
                }


                int new4 = int.Parse(Test4);

                int q1 = Global.firstTest;
                int q2 = Global.seconTest;
                int q3 = Global.thirdTest;

                //if (q1 == null || q2 == null || q3 == null || new4 == null)
                //{
                //    await MessagePopup.Instance.Show("All questions must be answered");
                //    return;
                //}

                int newResult = q1 + q2 + q3 + new4;

                if (newResult > 25)
                {
                    //await Navigation.PushAsync(new ScamResult());
                    Application.Current.MainPage = new NavigationPage(new EmploymentLikelyResult());

                    ScamResult = "The Q&A assessment strongly suggests a probable scam. Beware of unsolicited job offers, especially if sudden or unexpected. Always research the company, job description, and any associated details before accepting an employment opportunity. Don't share personal or financial info during application. Avoid sharing personal or financial information during application, and trust your instincts. Stay cautious, report any doubts, and proceed carefully.";

                    LikelyOrNot = "Likely a scam";

                    Global.likelyOrNot = LikelyOrNot;
                }
                else
                {
                    //await Navigation.PushAsync(new ScamResultTwo());
                    Application.Current.MainPage = new NavigationPage(new EmploymentUnlikelyResult());

                    ScamResult = "Based on the Q&A assessment, it indicates that there is a lower probability or minimal indication that the situation or offer is fraudulent. However, it's still important to remain cautious and attentive. While the initial evaluation suggests a lower likelihood of it being a scam, it's essential to understand that scammers are constantly evolving their tactics and can employ new techniques that may not yet be widely known or detected. Therefore, maintaining a vigilant mindset helps ensure ongoing scrutiny and proactive protection.";

                    LikelyOrNot = "Unlikely a scam";

                    Global.likelyOrNot = LikelyOrNot;
                }

                Global.NewScamResult = ScamResult;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public async Task PostFeedbackCommandExecute()
        {
            try
            {
                await LoadingPopup.Instance.Show("Saving Feedback...");

                HttpClient client = new HttpClient();


                string[] items = { "Is the job offer from a legitimate company or organization that you've researched and confirmed? ",
                                    "Are you being asked to pay upfront fees, provide personal financial information, or purchase expensive training materials as part of the job application process?",
                                    "Is the job description vague, promising high earnings with little to no effort or experience?",
                                    "Did you receive the job offer unsolicited, without having applied or interviewed for the position?"
                                };

                var newTest1 = Global.newResult1;
                var newTest2 = Global.newResult2;
                var newTest3 = Global.newResult3;
                var newTest4 = Global.newResult4;

                string[] numbers = { newTest1, newTest2, newTest3, newTest4 };

                List<QuestionAnswerData> itemList = new List<QuestionAnswerData>();

                // Combine the item and number lists into a list of ItemInfo objects
                for (int i = 0; i < Math.Min(items.Length, numbers.Length); i++)
                {
                    QuestionAnswerData itemInfo = new QuestionAnswerData
                    {
                        question = items[i],
                        answer = numbers[i]
                    };

                    itemList.Add(itemInfo);
                }

                var updatedResult = Global.NewScamResult;

                var scamlikely = Global.likelyOrNot;

                var newrating = Global.Rating;

                var UserComment = Global.comment;

                PostFeedbackRequestModel requestPayload = new PostFeedbackRequestModel()
                { questionAnswer = itemList, comment = UserComment, output = scamlikely, rating = newrating, outputDetails = updatedResult, scamType = "ATM Scam" };

                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(payloadJson);

                string url = Global.PostFeedbackUrl;

                Console.WriteLine(url);
                StringContent content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"{Global.Token}");

                HttpResponseMessage response;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    await MessagePopup.Instance.Show("Feedback saved Successfully");

                    Application.Current.MainPage = new NavigationPage(new Tabbed());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());

                }
                else
                {
                    await MessagePopup.Instance.Show("Something went wrong. Please try again later");

                }

            }
            catch (Exception ex)
            {
                await MessagePopup.Instance.Show("Something went wrong. Please try again later");

                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }

        #endregion
    }

}
