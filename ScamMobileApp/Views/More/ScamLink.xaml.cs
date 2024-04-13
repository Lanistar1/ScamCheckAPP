using ScamMobileApp.Helpers;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScamLink : ContentPage
    {
        public ScamLink()
        {
            InitializeComponent();
            BindingContext = new ReportScamViewModel(Navigation);

        }

        #region Australia
        private async void Scamwatch(object sender, EventArgs e)
        {

            string url = "https://www.scamwatch.gov.au"; // Replace with your desired URL

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void AustraliaCyber(object sender, EventArgs e)
        {

            string url = "https://www.cyber.gov.au/report-and-recover/report"; // Replace with your desired URL

            await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }

        private async void ACMA(object sender, EventArgs e)
        {

            string url = "https://www.acma.gov.au/spam-complaint-form"; // Replace with your desired URL

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Canada
        private async void CyberSecurity(object sender, EventArgs e)
        {

            string url = "https://www.cyber.gc.ca/en/incident-management";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void AntiFraud(object sender, EventArgs e)
        {

            string url = "https://www.antifraudcentre-centreantifraude.ca/report-signalez-eng.htm"; 

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void TrafficServices(object sender, EventArgs e)
        {

            string url = "https://www.tps.ca/fraud"; 

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region France
        private async void OutreMer(object sender, EventArgs e)
        {

            string url = "https://www.internet-signalement.gouv.fr/PharosS1";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void DigitalSovereignty(object sender, EventArgs e)
        {

            string url = "https://www.economie.gouv.fr";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void ServicePublic(object sender, EventArgs e)
        {

            string url = "https://www.service-public.fr/particuliers/actualites/A15558?lang=en";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Germany
        private async void Polizei(object sender, EventArgs e)
        {

            string url = "https://www.polizei.de/Polizei/DE/Home/home_node.html";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Bundeskriminalamt(object sender, EventArgs e)
        {

            string url = "https://www.bka.de/EN/OurTasks/AreasOfCrime/Cybercrime/cybercrime_node.html";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region India
        private async void CyberCrime(object sender, EventArgs e)
        {

            string url = "https://cybercrime.gov.in";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Portal(object sender, EventArgs e)
        {

            string url = "https://cybervolunteer.mha.gov.in/Default.aspx";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void DelhiPolice(object sender, EventArgs e)
        {

            string url = "https://cyber.delhipolice.gov.in";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Ireland
        private async void Ireland1(object sender, EventArgs e)
        {

            string url = "https://www.garda.ie/en/crime/fraud";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Ireland12(object sender, EventArgs e)
        {

            string url = "https://garda.ie/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Israel
        private async void Israel1(object sender, EventArgs e)
        {

            string url = "http://www.btl.gov.il/English%20Homepage/stations/Call%20Centers/Pages/reporting-fraud.aspx";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Italy
        private async void italy1(object sender, EventArgs e)
        {

            string url = "https://www.poliziadistato.it/articolo/welcome";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Japan
        private async void japan1(object sender, EventArgs e)
        {

            string url = "https://japanantifraud.org/report-a-fraud-in-japan";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Netherland
        private async void Netherland1(object sender, EventArgs e)
        {

            string url = "https://www.politie.nl/aangifte-of-melding-doen/aangifte-van-oplichting.html"; 

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Netherland2(object sender, EventArgs e)
        {

            string url = "https://www.fraudehelpdesk.nl/fraudhelpdesk-the-dutch-national-anti-fraud-hotline/#:~:text=We%20are%20the%20Dutch%20national,by%20telephone%3A%20088%20%E2%80%93%207867372.";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region New Zealand
        private async void Zealand1(object sender, EventArgs e)
        {

            string url = "https://reportspam.co.nz/";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Zealand2(object sender, EventArgs e)
        {

            string url = "https://report.netsafe.org.nz/hc/en-au/requests/";

            await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }

        private async void Zealand3(object sender, EventArgs e)
        {

            string url = "https://bankomb.org.nz/guides-and-cases/quick-guides/other/common-scams-targeting-bank-customers/";

            await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }
        #endregion

        #region Saudi Arabia
        private async void Arabia1(object sender, EventArgs e)
        {

            string url = "https://www.my.gov.sa/wps/portal/snp/servicesDirectory/servicedetails/7453/!ut/p/z0/04_Sj9CPykssy0xPLMnMz0vMAfIjo8zivQIsTAwdDQz9LQwNzQwCnS0tXPwMvYwN3A30g1Pz9L30o_ArAppiVOTr7JuuH1WQWJKhm5mXlq8fYW5iaqxfkO0eDgCtqo3n/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        private async void Arabia2(object sender, EventArgs e)
        {

            string url = "http://www.mup.gov.rs/wps/portal/en/directorate/!ut/p/z1/04_Sj9CPykssy0xPLMnMz0vMAfIjo8zi_S19zQzdDYy83X18nQwczcyNLVz9TI0M3I30C7IdFQG85wg0/";

            await Navigation.PushAsync(new WebviewPage(url));

        }


        #endregion

        #region Singapore
        private async void Singapore1(object sender, EventArgs e)
        {

            string url = "https://form.gov.sg/63982e109841390011a59121";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Singapore2(object sender, EventArgs e)
        {

            string url = "https://eservices.police.gov.sg/content/policehubhome/homepage/police-report.html";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Singapore3(object sender, EventArgs e)
        {

            string url = "https://www.case.org.sg/submit-a-complaint/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region South Africa
        private async void SAfrica(object sender, EventArgs e)
        {

            string url = "https://www.icasa.org.za/pages/report-fraud";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region South Korea
        private async void Korea1(object sender, EventArgs e)
        {

            string url = "https://fgn.kics.go.kr/en/jsp/forum/crimeReport01.jsp";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Korea2(object sender, EventArgs e)
        {

            string url = "https://www.police.go.kr/eng/main.do";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Spain
        private async void Spain(object sender, EventArgs e)
        {

            string url = "https://www.policia.es/_es/denuncias.php";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Switzerland
        private async void Switzerland1(object sender, EventArgs e)
        {

            string url = "https://www.suisse-epolice.ch/#/cybercrime-case";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Switzerland2(object sender, EventArgs e)
        {

            string url = "https://www.govcert.ch/report/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Ukraine
        private async void Ukraine1(object sender, EventArgs e)
        {

            string url = "https://mvs.gov.ua/en/contacts/national-police-ukraine";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Ukraine2(object sender, EventArgs e)
        {

            string url = "https://nabu.gov.ua/en/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region UAE
        private async void UAE1(object sender, EventArgs e)
        {

            string url = "https://u.ae/en/information-and-services/justice-safety-and-the-law/cyber-safety-and-digital-security/report-cybercrimes-online";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region United Kingdom
        private async void Kingdom1(object sender, EventArgs e)
        {

            string url = "https://reporting.actionfraud.police.uk/login";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Kingdom2(object sender, EventArgs e)
        {

            string url = "https://www.nationalcrimeagency.gov.uk/what-we-do/crime-threats/fraud-and-economic-crime#:~:text=Report%20all%20incidents%20of%20fraud,In%20an%20emergency%2C%20call%20999.";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Kingdom3(object sender, EventArgs e)
        {

            string url = "https://www.citizensadvice.org.uk/consumer/scams/reporting-a-scam/";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region USA
        private async void USA1(object sender, EventArgs e)
        {

            string url = "https://reportfraud.ftc.gov/#/";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void USA2(object sender, EventArgs e)
        {

            string url = "https://www.identitytheft.gov";

            await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void USA3(object sender, EventArgs e)
        {

            string url = "https://www.ic3.gov/Home/ComplaintChoice";

            await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

    }
}