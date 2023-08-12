using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class PreventiveTipsViewModel : BaseViewModel
    {
        private INavigation Navigation;

        public PreventiveTipsViewModel(INavigation navigation)
        {
            Navigation = navigation;

            // for unsolicted
            ShowSolicitCommand = new Command(async () => await ShowSolicitCommandExecute());
            ShowSolicitDetailCommand = new Command(async () => await ShowSolicitDetailCommandExecute());

            // for pressure tactics
            ShowPressureTacticsCommand = new Command(async () => await ShowPressureTacticsCommandExecute());
            ShowPressureTacticsDetailCommand = new Command(async () => await ShowPressureTacticsDetailCommandExecute());

            // for personal details
            ShowPersonalInfoCommand = new Command(async () => await ShowPersonalInfoCommandCommandExecute());
            ShowPersonalInfoDetailCommand = new Command(async () => await ShowPersonalInfoDetailCommandExecute());

            // for good offer
            ShowGoodOfferCommand = new Command(async () => await ShowGoodOfferCommandExecute());
            ShowGoodOfferDetailCommand = new Command(async () => await ShowGoodOfferDetailCommandExecute());

            // for suspicious payment
            ShowSuspiciousPaymentCommand = new Command(async () => await ShowSuspiciousPaymentCommandExecute());
            ShowSuspiciousPaymentDetailCommand = new Command(async () => await ShowSuspiciousPaymentDetailCommandExecute());

            //for poor grammar
            ShowPoorGrammarCommand = new Command(async () => await ShowPoorGrammarCommandExecute());
            ShowPoorGrammarDetailCommand = new Command(async () => await ShowPoorGrammarDetailCommandExecute());

            // for fake website
            ShowFakeWebsiteCommand = new Command(async () => await ShowFakeWebsiteCommandCommandExecute());
            ShowFakeWebsiteDetailCommand = new Command(async () => await ShowFakeWebsiteDetailCommandCommandExecute());

            // for emotional appeals
            ShowEmotionalAppealsCommand = new Command(async () => await ShowEmotionalAppealsCommandCommandCommandExecute());
            ShowEmotionalAppealsDetailCommand = new Command(async () => await ShowEmotionalAppealsDetailCommandCommandExecute());


        }

        private bool solicitVisible = true;
        public bool SolicitVisible
        {
            get => solicitVisible;
            set
            {
                solicitVisible = value;
                OnPropertyChanged(nameof(SolicitVisible));
            }
        }

        private bool solicitDetailVisible = false;
        public bool SolicitDetailVisible
        {
            get => solicitDetailVisible;
            set
            {
                solicitDetailVisible = value;
                OnPropertyChanged(nameof(SolicitDetailVisible));
            }
        }

        private bool pressureTacticsVisible = true;
        public bool PressureTacticsVisible
        {
            get => pressureTacticsVisible;
            set
            {
                pressureTacticsVisible = value;
                OnPropertyChanged(nameof(PressureTacticsVisible));
            }
        }

        private bool pressureTacticsDetailVisible = false;
        public bool PressureTacticsDetailVisible
        {
            get => pressureTacticsDetailVisible;
            set
            {
                pressureTacticsDetailVisible = value;
                OnPropertyChanged(nameof(PressureTacticsDetailVisible));
            }
        }


        private bool personalInfoVisible = true;
        public bool PersonalInfoVisible
        {
            get => personalInfoVisible;
            set
            {
                personalInfoVisible = value;
                OnPropertyChanged(nameof(PersonalInfoVisible));
            }
        }

        private bool personalInfoDetailVisible = false;
        public bool PersonalInfoDetailVisible
        {
            get => personalInfoDetailVisible;
            set
            {
                personalInfoDetailVisible = value;
                OnPropertyChanged(nameof(PersonalInfoDetailVisible));
            }
        }


        private bool goodOfferVisible = true;
        public bool GoodOfferVisible
        {
            get => goodOfferVisible;
            set
            {
                goodOfferVisible = value;
                OnPropertyChanged(nameof(GoodOfferVisible));
            }
        }

        private bool goodOfferDetailVisible = false;
        public bool GoodOfferDetailVisible
        {
            get => goodOfferDetailVisible;
            set
            {
                goodOfferDetailVisible = value;
                OnPropertyChanged(nameof(GoodOfferDetailVisible));
            }
        }


        private bool suspiciousPaymentVisible = true;
        public bool SuspiciousPaymentVisible
        {
            get => suspiciousPaymentVisible;
            set
            {
                suspiciousPaymentVisible = value;
                OnPropertyChanged(nameof(SuspiciousPaymentVisible));
            }
        }

        private bool suspiciousPaymentDetailVisible = false;
        public bool SuspiciousPaymentDetailVisible
        {
            get => suspiciousPaymentDetailVisible;
            set
            {
                suspiciousPaymentDetailVisible = value;
                OnPropertyChanged(nameof(SuspiciousPaymentDetailVisible));
            }
        }

        private bool poorGrammarVisible = true;
        public bool PoorGrammarVisible
        {
            get => poorGrammarVisible;
            set
            {
                poorGrammarVisible = value;
                OnPropertyChanged(nameof(PoorGrammarVisible));
            }
        }

        private bool poorGrammarDetailVisible = false;
        public bool PoorGrammarDetailVisible
        {
            get => poorGrammarDetailVisible;
            set
            {
                poorGrammarDetailVisible = value;
                OnPropertyChanged(nameof(PoorGrammarDetailVisible));
            }
        }


        private bool fakeWebsiteVisible = true;
        public bool FakeWebsiteVisible
        {
            get => fakeWebsiteVisible;
            set
            {
                fakeWebsiteVisible = value;
                OnPropertyChanged(nameof(FakeWebsiteVisible));
            }
        }

        private bool fakeWebsiteDetailVisible = false;
        public bool FakeWebsiteDetailVisible
        {
            get => fakeWebsiteDetailVisible;
            set
            {
                fakeWebsiteDetailVisible = value;
                OnPropertyChanged(nameof(FakeWebsiteDetailVisible));
            }
        }


        private bool emotionalAppealsVisible = true;
        public bool EmotionalAppealsVisible
        {
            get => emotionalAppealsVisible;
            set
            {
                emotionalAppealsVisible = value;
                OnPropertyChanged(nameof(EmotionalAppealsVisible));
            }
        }

        private bool emotionalAppealsDetailVisible = false;
        public bool EmotionalAppealsDetailVisible
        {
            get => emotionalAppealsDetailVisible;
            set
            {
                emotionalAppealsDetailVisible = value;
                OnPropertyChanged(nameof(EmotionalAppealsDetailVisible));
            }
        }


        // command
        public ICommand ShowSolicitCommand { get; }
        public ICommand ShowSolicitDetailCommand { get; }
        public ICommand ShowPressureTacticsDetailCommand { get; }
        public ICommand ShowPressureTacticsCommand { get; }
        public ICommand ShowPersonalInfoCommand { get; }
        public ICommand ShowPersonalInfoDetailCommand { get; }
        public ICommand ShowGoodOfferCommand { get; }
        public ICommand ShowGoodOfferDetailCommand { get; }
        public ICommand ShowSuspiciousPaymentCommand { get; }
        public ICommand ShowSuspiciousPaymentDetailCommand { get; }
        public ICommand ShowPoorGrammarCommand { get; }
        public ICommand ShowPoorGrammarDetailCommand { get; }
        public ICommand ShowFakeWebsiteCommand { get; }
        public ICommand ShowFakeWebsiteDetailCommand { get; }
        public ICommand ShowEmotionalAppealsCommand { get; }
        public ICommand ShowEmotionalAppealsDetailCommand { get; }



        // unsolicited communication
        private async Task ShowSolicitCommandExecute()
        {
            try
            {
                SolicitDetailVisible = true;
                SolicitVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowSolicitDetailCommandExecute()
        {
            try
            {
                SolicitDetailVisible = false;
                SolicitVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for pressure tactics

        private async Task ShowPressureTacticsCommandExecute()
        {
            try
            {
                pressureTacticsVisible = false;
                PressureTacticsDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowPressureTacticsDetailCommandExecute()
        {
            try
            {
                PressureTacticsDetailVisible = false;
                pressureTacticsVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for personal info
        private async Task ShowPersonalInfoCommandCommandExecute()
        {
            try
            {
                PersonalInfoVisible = false;
                PersonalInfoDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowPersonalInfoDetailCommandExecute()
        {
            try
            {
                PersonalInfoDetailVisible = false;
                PersonalInfoVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for good offer

        private async Task ShowGoodOfferCommandExecute()
        {
            try
            {
                GoodOfferVisible = false;
                GoodOfferDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowGoodOfferDetailCommandExecute()
        {
            try
            {
                GoodOfferDetailVisible = false;
                GoodOfferVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for suspicious payment

        private async Task ShowSuspiciousPaymentCommandExecute()
        {
            try
            {
                SuspiciousPaymentVisible = false;
                SuspiciousPaymentDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowSuspiciousPaymentDetailCommandExecute()
        {
            try
            {
                SuspiciousPaymentDetailVisible = false;
                SuspiciousPaymentVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for poor grammar

        private async Task ShowPoorGrammarCommandExecute()
        {
            try
            {
                PoorGrammarVisible = false;
                PoorGrammarDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowPoorGrammarDetailCommandExecute()
        {
            try
            {
                PoorGrammarDetailVisible = false;
                PoorGrammarVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for fake website
        private async Task ShowFakeWebsiteCommandCommandExecute()
        {
            try
            {
                FakeWebsiteVisible = false;
                FakeWebsiteDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowFakeWebsiteDetailCommandCommandExecute()
        {
            try
            {
                FakeWebsiteDetailVisible = false;
                FakeWebsiteVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // for fake website
        private async Task ShowEmotionalAppealsCommandCommandCommandExecute()
        {
            try
            {
                EmotionalAppealsVisible = false;
                EmotionalAppealsDetailVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ShowEmotionalAppealsDetailCommandCommandExecute()
        {
            try
            {
                EmotionalAppealsDetailVisible = false;
                EmotionalAppealsVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}
