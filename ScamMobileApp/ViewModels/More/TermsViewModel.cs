using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class TermsViewModel : BaseViewModel
    {
        private INavigation Navigation;

        #region Bindings
        private string antiScam;
        public string AntiScam
        {
            get => antiScam;
            set
            {
                antiScam = value;
                OnPropertyChanged(nameof(AntiScam));
            }
        }

        private string terms;
        public string Terms
        {
            get => terms;
            set
            {
                terms = value;
                OnPropertyChanged(nameof(Terms));
            }
        }

        private string questionandAnswer;
        public string QuestionandAnswer
        {
            get => questionandAnswer;
            set
            {
                questionandAnswer = value;
                OnPropertyChanged(nameof(QuestionandAnswer));
            }
        }

        private string automatedQA;
        public string AutomatedQA
        {
            get => automatedQA;
            set
            {
                automatedQA = value;
                OnPropertyChanged(nameof(AutomatedQA));
            }
        }

        private string decisionQA;
        public string DecisionQA
        {
            get => decisionQA;
            set
            {
                decisionQA = value;
                OnPropertyChanged(nameof(DecisionQA));
            }
        }

        private string nextQA;
        public string NextQA
        {
            get => nextQA;
            set
            {
                nextQA = value;
                OnPropertyChanged(nameof(NextQA));
            }
        }

        private string intro;
        public string Intro
        {
            get => intro;
            set
            {
                intro = value;
                OnPropertyChanged(nameof(Intro));
            }
        }
        #endregion

        public TermsViewModel(INavigation navigation)
        {
            AntiScam = "The Anti-Scam Movement refers to a collective effort aimed at raising awareness about scams, empowering individuals with knowledge and tools to identify and prevent scams, and promoting a community of vigilant individuals who actively combat fraudulent activities. The movement encourages people to unite against scams, share information, support victims, and work towards creating a safer environment.By joining the movement, you become part of a community of individuals dedicated to learning, sharing experiences, and supporting one another in the fight against scams. Together, we empower ourselves to be better, more informed, and more secure.\r\nUsers are welcome to share their scam or fraud experiences in text format only on this page.";

            Terms = "Terms & Conditions and Disclaimer:";

            QuestionandAnswer = "9. ScamQ&A Feature";

            AutomatedQA = " The ScamQ&A feature provides an automated assessment based on user responses. Users should recognize that these assessments are algorithm-based and not a substitute for professional advice.";

            DecisionQA = " SCAMalicious does not guarantee the accuracy of ScamQ&A assessments and users are encouraged to exercise their judgment. ";

            NextQA = "ScamQ&A may provide recommendations for next steps based on the assessment, but users are responsible for their decisions and actions.";

            Intro = "Welcome to SCAMalicious (referred to as \"the App\" or \"the Website\"). By accessing or using the App/Website, you agree to comply with and be bound by these Terms and Conditions.";
        }

    }

}
