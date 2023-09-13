using ScamMobileApp.Helpers;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Questions;
using ScamMobileApp.Views.Questions.ATM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.ScamCalculator
{

    public class ATMViewModel : BaseViewModel
    {
        public ATMViewModel(INavigation navigation)
        {
            Navigation = navigation;

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
        #endregion

        #region Commands
        public ICommand ScamCalculatorCommand { get; }
        public ICommand FirstQuestionCommand { get; }
        public ICommand SecondQuestionCommand { get; }
        public ICommand ThirdQuestionCommand { get; }

        #endregion

        #region functions, methods, events and Navigations

        private async Task FirstQuestionCommandExecute()
        {
            if (QuestionOneCheckYes == true && QuestionOneCheckNo == false)
            {
                Test1 = "25";
            }
            else if (QuestionOneCheckYes == false && QuestionOneCheckNo == true)
            {
                Test1 = "0";
            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 1 to proceed");
                return;
            }
            int new1 = int.Parse(Test1);

            Global.firstTest = new1;

            await Navigation.PushAsync(new ATMSecondQuestion());

        }

        private async Task SecondQuestionCommandExecute()
        {

            if (QuestionTwoCheckYes == true && QuestionTwoCheckNo == false)
            {
                Test2 = "25";
            }
            else if (QuestionTwoCheckYes == false && QuestionTwoCheckNo == true)
            {
                Test2 = "0";
            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 2 to proceed");
                return;
            }

            int new2 = int.Parse(Test2);

            Global.seconTest = new2;
            await Navigation.PushAsync(new ATMThirdQuestion());

        }

        private async Task ThirdQuestionCommandExecute()
        {

            if (QuestionThreeCheckYes == true && QuestionThreeCheckNo == false)
            {
                Test3 = "25";
            }
            else if (QuestionThreeCheckYes == false && QuestionThreeCheckNo == true)
            {
                Test3 = "0";
            }
            else
            {
                await MessagePopup.Instance.Show("Please answer question 3 to proceed");
                return;
            }
            int new3 = int.Parse(Test3);

            Global.thirdTest = new3;

            await Navigation.PushAsync(new ATMFourthQuestion());

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
                    Application.Current.MainPage = new NavigationPage(new AtmLikelyResult());

                }
                else
                {
                    //await Navigation.PushAsync(new ScamResultTwo());
                    Application.Current.MainPage = new NavigationPage(new AtmUnlikelyResult());

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
