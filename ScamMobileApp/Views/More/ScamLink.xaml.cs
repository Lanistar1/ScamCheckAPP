using ScamMobileApp.Helpers;
using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            //await Launcher.OpenAsync(new Uri(url));

            await Launcher.OpenAsync(url);


            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void AustraliaCyber(object sender, EventArgs e)
        {

            string url = "https://www.cyber.gov.au/report-and-recover/report"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));


            //await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }

        private async void ACMA(object sender, EventArgs e)
        {

            string url = "https://www.acma.gov.au/spam-complaint-form"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));


            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Argentina
        private async void Argentina(object sender, EventArgs e)
        {

            string url = "https://www.argentina.gob.ar/servicio/denunciar-un-delito-informatico"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Austria
        private async void austria1(object sender, EventArgs e)
        {

            string url = "https://www.bmf.gv.at/en/the-ministry/internal-organisation/Anti-Fraud-Office-.html"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void austria2(object sender, EventArgs e)
        {

            string url = "https://www.fma.gv.at/en/complaints-and-points-of-contact"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Belgium
        private async void Belgium1(object sender, EventArgs e)
        {

            string url = "https://www.cert.be/en/report-incident"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Belgium2(object sender, EventArgs e)
        {

            string url = "https://meldpunt.belgie.be/meldpunt"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Belgium3(object sender, EventArgs e)
        {

            string url = "https://www.police.be/en/online-reporting/online-reporting"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Brazil
        private async void Brazil1(object sender, EventArgs e)
        {

            string url = "https://www.cert.br/en/"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Bulgaria
        private async void Bulgaria1(object sender, EventArgs e)
        {

            string url = "https://www.cert.be/en/report-incident"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Bulgaria2(object sender, EventArgs e)
        {

            string url = "https://meldpunt.belgie.be/meldpunt/"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Bulgaria3(object sender, EventArgs e)
        {

            string url = "https://www.police.be/en/online-reporting/online-reporting"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Canada
        private async void CyberSecurity(object sender, EventArgs e)
        {

            string url = "https://www.cyber.gc.ca/en/incident-management";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void AntiFraud(object sender, EventArgs e)
        {

            string url = "https://www.antifraudcentre-centreantifraude.ca/report-signalez-eng.htm";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void TrafficServices(object sender, EventArgs e)
        {

            string url = "https://www.tps.ca/fraud";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region China
        private async void china1(object sender, EventArgs e)
        {

            string url = "https://www.cbirc.gov.cn/cn/view/pages/ItemList.html?itemPId=960&itemId=4097&itemUrl=ItemListRightMore.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void china2(object sender, EventArgs e)
        {

            string url = "https://www.consumersinternational.org/what-we-do/digital-rights/anti-scams/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void china3(object sender, EventArgs e)
        {

            string url = "http://www.csrc.gov.cn/csrc_en/index.shtml";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion


        #region Czech
        private async void Czech1(object sender, EventArgs e)
        {

            string url = "https://www.mvcr.cz/mvcren/article/complaints.aspx"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Czech2(object sender, EventArgs e)
        {

            string url = "https://www.bkb.cz/en/victim-support/how-to-report-a-crime-in-the-czech-republic/"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Czech3(object sender, EventArgs e)
        {

            string url = "https://www.policie.cz/clanek/Police-of-the-Czech-Republic.aspx"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Croatia
        private async void Croatia1(object sender, EventArgs e)
        {

            string url = "https://gov.hr/en/reporting-a-criminal-offence/1134"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Denmark
        private async void Denmark1(object sender, EventArgs e)
        {

            string url = "https://politi.dk/anmeld-kriminalitet"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

           // await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Denmark2(object sender, EventArgs e)
        {

            string url = "https://international.kk.dk/live/report-to-the-authorities#:~:text=Report%20to%20the%20authorities%20%7C%20International.kk.dk"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Denmark3(object sender, EventArgs e)
        {

            string url = "https://um.dk/en/travel-and-residence/visa-complaint"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Egypt
        private async void Egypt1(object sender, EventArgs e)
        {

            string url = "https://www.cpa.gov.eg/en-us/Complaints"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Estonia
        private async void Estonia1(object sender, EventArgs e)
        {

            string url = "https://cyber.politsei.ee/en"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Estonia2(object sender, EventArgs e)
        {

            string url = "https://www.eesti.ee/en/legal-advice/crime-and-punishments/in-case-of-a-criminal-offence"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Finland
        private async void Finland1(object sender, EventArgs e)
        {

            string url = "https://poliisi.fi/en/net-tip"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Finland2(object sender, EventArgs e)
        {

            string url = "https://www.kkv.fi/en/consumer-affairs/scams/report-a-scam/#:~:text=Report%20a%20scam%20%E2%80%93%20Finnish%20Competition%20and%20Consumer%20Authority"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Finland3(object sender, EventArgs e)
        {

            string url = "https://korruptiontorjunta.fi/en/report-corruption"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region France
        private async void OutreMer(object sender, EventArgs e)
        {

            string url = "https://www.internet-signalement.gouv.fr/PharosS1";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void DigitalSovereignty(object sender, EventArgs e)
        {

            string url = "https://www.economie.gouv.fr";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void ServicePublic(object sender, EventArgs e)
        {

            string url = "https://www.service-public.fr/particuliers/actualites/A15558?lang=en";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Germany
        private async void Polizei(object sender, EventArgs e)
        {

            string url = "https://www.polizei.de/Polizei/DE/Home/home_node.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Bundeskriminalamt(object sender, EventArgs e)
        {

            string url = "https://www.bka.de/EN/OurTasks/AreasOfCrime/Cybercrime/cybercrime_node.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Greece
        private async void Greece1(object sender, EventArgs e)
        {

            string url = "https://www.gov.gr/en/sdg/public-contracts/reporting-irregularities/general/authorities-to-which-complaints-for-irregularities-can-be-submitted"; // Replace with your desired URL

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Hungary
        private async void Hungary1(object sender, EventArgs e)
        {

            string url = "https://transparency.hu/en/rolunk/panaszkezeles/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Hungary2(object sender, EventArgs e)
        {

            string url = "https://www.police.hu/en";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region India
        private async void CyberCrime(object sender, EventArgs e)
        {

            string url = "https://cybercrime.gov.in";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Portal(object sender, EventArgs e)
        {

            string url = "https://cybervolunteer.mha.gov.in/Default.aspx";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void DelhiPolice(object sender, EventArgs e)
        {

            string url = "https://cyber.delhipolice.gov.in";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Indonesia
        private async void Indonesia1(object sender, EventArgs e)
        {

            string url = "https://www.polri.go.id/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Ireland
        private async void Ireland1(object sender, EventArgs e)
        {

            string url = "https://www.garda.ie/en/crime/fraud/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Ireland2(object sender, EventArgs e)
        {

            string url = "https://garda.ie/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Israel
        private async void Israel1(object sender, EventArgs e)
        {

            string url = "http://www.btl.gov.il/English%20Homepage/stations/Call%20Centers/Pages/reporting-fraud.aspx";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Italy
        private async void italy1(object sender, EventArgs e)
        {

            string url = "https://www.poliziadistato.it/articolo/welcome";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Japan
        private async void japan1(object sender, EventArgs e)
        {

            string url = "https://japanantifraud.org/report-a-fraud-in-japan";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Latvia
        private async void Latvia1(object sender, EventArgs e)
        {

            string url = "https://www.vp.gov.lv/en/branches";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Lithuania
        private async void Lithuania1(object sender, EventArgs e)
        {

            string url = "https://www.fntt.lt/en/investigation/224?__cf_chl_tk=VbYaUh2_eZlsBbYIrZAuG0zvLjxTiZsh3vLD.AtO750-1692535259-0-gaNycGzNC2U";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Lithuania2(object sender, EventArgs e)
        {

            string url = "https://invega.lt/en/report-corruption/107";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Malaysia
        private async void Malaysia1(object sender, EventArgs e)
        {

            string url = "http://www.rmp.gov.my/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Malaysia2(object sender, EventArgs e)
        {

            string url = "https://nfcc.jpm.gov.my/index.php/en/soalan/mengenainsrc";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Mauritius
        private async void Mauritius1(object sender, EventArgs e)
        {

            string url = "https://www.bom.mu/financial-stability/supervision/reporting-financial-crime/fraudscam-reporting-form";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Mauritius2(object sender, EventArgs e)
        {

            string url = "https://maucors.govmu.org/maucors/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Mexico
        private async void Mexico1(object sender, EventArgs e)
        {

            string url = "https://mexicocity.cdmx.gob.mx/e/basics-for-mexico-city-travel/filing-consumer-complaints-mexico/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Mexico2(object sender, EventArgs e)
        {

            string url = "https://www.banxico.org.mx/footer-en/warning-queries-banco-mexic.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Netherland
        private async void Netherland1(object sender, EventArgs e)
        {

            string url = "https://www.politie.nl/aangifte-of-melding-doen/aangifte-van-oplichting.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Netherland2(object sender, EventArgs e)
        {

            string url = "https://www.fraudehelpdesk.nl/fraudhelpdesk-the-dutch-national-anti-fraud-hotline/#:~:text=We%20are%20the%20Dutch%20national,by%20telephone%3A%20088%20%E2%80%93%207867372.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region New Zealand
        private async void Zealand1(object sender, EventArgs e)
        {

            string url = "https://reportspam.co.nz/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Zealand2(object sender, EventArgs e)
        {

            string url = "https://report.netsafe.org.nz/hc/en-au/requests/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }

        private async void Zealand3(object sender, EventArgs e)
        {

            string url = "https://bankomb.org.nz/guides-and-cases/quick-guides/other/common-scams-targeting-bank-customers/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

            //await Launcher.OpenAsync(url);
        }
        #endregion

        #region Norway
        private async void Norway1(object sender, EventArgs e)
        {

            string url = "https://www.politiet.no/en/english/report-a-crime/#:~:text=Please%20call%2002800%20for%20help,the%20forms%20are%20in%20Norwegian.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Norway2(object sender, EventArgs e)
        {

            string url = "https://nhrf.no/contact/report-fraud-or-abuse";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Norway3(object sender, EventArgs e)
        {

            string url = "https://www.sikresiden.no/en/onlinefraud";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Pakistan
        private async void Pakistan1(object sender, EventArgs e)
        {

            string url = "https://www.nr3c.gov.pk/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Pakistan2(object sender, EventArgs e)
        {

            string url = "https://fia.gov.pk/complaints_dept";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Philippines
        private async void Philippines1(object sender, EventArgs e)
        {

            string url = "https://www.dof.gov.ph/anti-fraud/#:~:text=You%20may%20also%20report%20these,and%20messages%20containing%20false%20information.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Philippines2(object sender, EventArgs e)
        {

            string url = "https://www.foi.gov.ph/requests?agency=NBI";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Poland
        private async void Poland1(object sender, EventArgs e)
        {

            string url = "https://lublin.policja.gov.pl/llu/prewencja/for-foreigners/64546,How-to-officially-notify-the-Police-about-an-offence.html?sid=7dc1bce13bed7a7e6f4ceff3bd055556";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Poland2(object sender, EventArgs e)
        {

            string url = "https://konsument.gov.pl/en/complaint/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Portugal
        private async void Portugal1(object sender, EventArgs e)
        {

            string url = "https://www.policiajudiciaria.pt/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Portugal2(object sender, EventArgs e)
        {

            string url = "https://en.ministeriopublico.pt/perguntas-frequentes/corruption";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Portugal3(object sender, EventArgs e)
        {

            string url = "https://www.safecommunitiesportugal.com/report-a-crime-online/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Romania
        private async void Romania1(object sender, EventArgs e)
        {

            string url = "https://www.politiaromana.ro/en/romanian-police";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Saudi Arabia
        private async void Arabia1(object sender, EventArgs e)
        {

            string url = "https://www.my.gov.sa/wps/portal/snp/servicesDirectory/servicedetails/7453/!ut/p/z0/04_Sj9CPykssy0xPLMnMz0vMAfIjo8zivQIsTAwdDQz9LQwNzQwCnS0tXPwMvYwN3A30g1Pz9L30o_ArAppiVOTr7JuuH1WQWJKhm5mXlq8fYW5iaqxfkO0eDgCtqo3n/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        private async void Arabia2(object sender, EventArgs e)
        {

            string url = "http://www.mup.gov.rs/wps/portal/en/directorate/!ut/p/z1/04_Sj9CPykssy0xPLMnMz0vMAfIjo8zi_S19zQzdDYy83X18nQwczcyNLVz9TI0M3I30C7IdFQG85wg0/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }


        #endregion

        #region Serbia
        private async void Serbia1(object sender, EventArgs e)
        {

            string url = "http://www.mup.gov.rs/wps/portal/en/directorate/!ut/p/z1/04_Sj9CPykssy0xPLMnMz0vMAfIjo8zi_S19zQzdDYy83X18nQwczcyNLVz9TI0M3I30C7IdFQG85wg0/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Singapore
        private async void Singapore1(object sender, EventArgs e)
        {

            string url = "https://form.gov.sg/63982e109841390011a59121";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Singapore2(object sender, EventArgs e)
        {

            string url = "https://eservices.police.gov.sg/content/policehubhome/homepage/police-report.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Singapore3(object sender, EventArgs e)
        {

            string url = "https://www.case.org.sg/submit-a-complaint/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Slovakia
        private async void Slovakia1(object sender, EventArgs e)
        {

            string url = "https://www.minv.sk/swift_data/source/images/slovak-republic-report-dezinfo-2021.pdf";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Slovenia
        private async void Slovenia1(object sender, EventArgs e)
        {

            string url = "https://www.policija.si/eng/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Slovenia2(object sender, EventArgs e)
        {

            string url = "https://www.gov.si/en/state-authorities/bodies-within-ministries/police/\r\n";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region South Africa
        private async void SAfrica(object sender, EventArgs e)
        {

            string url = "https://www.icasa.org.za/pages/report-fraud";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region South Korea
        private async void Korea1(object sender, EventArgs e)
        {

            string url = "https://fgn.kics.go.kr/en/jsp/forum/crimeReport01.jsp";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Korea2(object sender, EventArgs e)
        {

            string url = "https://www.police.go.kr/eng/main.do";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Spain
        private async void Spain(object sender, EventArgs e)
        {

            string url = "https://www.policia.es/_es/denuncias.php";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Sri Lanka
        private async void Lanka1(object sender, EventArgs e)
        {

            string url = "https://ciaboc.gov.lk/contact/complaints";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Lanka2(object sender, EventArgs e)
        {

            string url = "https://www.onlinesafety.lk/2021/06/18/be-vigilant-avoid-yourself-from-becoming-a-victim-of-a-scam/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Lanka3(object sender, EventArgs e)
        {

            string url = "https://www.ecpat.lk/reporting-mechanism/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Sweden
        private async void Sweden1(object sender, EventArgs e)
        {

            string url = "https://www.politiet.no/en/english/report-a-crime/#:~:text=Please%20call%2002800%20for%20help,the%20forms%20are%20in%20Norwegian.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Sweden2(object sender, EventArgs e)
        {

            string url = "https://www.fi.se/en/consumer-protection/investment-fraud/have-you-experienced-investment-fraud/#:~:text=Report%20what%20happened%20to%20the,can%20help%20by%20warning%20others.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Sweden3(object sender, EventArgs e)
        {

            string url = "http://skatteverket.se/servicelankar/otherlanguages/inenglishengelska/moreonskatteverket/reportsuspectedfraudorerrors.4.3016b5d91791bf546791.html";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Switzerland
        private async void Switzerland1(object sender, EventArgs e)
        {

            string url = "https://www.suisse-epolice.ch/#/cybercrime-case";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Switzerland2(object sender, EventArgs e)
        {

            string url = "https://www.govcert.ch/report/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region Thailand
        private async void Thailand1(object sender, EventArgs e)
        {

            string url = "https://www.thailandlaw.org/fraud-in-thailand.html";

            await Launcher.OpenAsync(new Uri(url));

           // await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Turkey
        private async void Turkey1(object sender, EventArgs e)
        {

            string url = "https://tib.gov.tr/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region Ukraine
        private async void Ukraine1(object sender, EventArgs e)
        {

            string url = "https://mvs.gov.ua/en/contacts/national-police-ukraine";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Ukraine2(object sender, EventArgs e)
        {

            string url = "https://nabu.gov.ua/en/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region UAE
        private async void UAE1(object sender, EventArgs e)
        {

            string url = "https://u.ae/en/information-and-services/justice-safety-and-the-law/cyber-safety-and-digital-security/report-cybercrimes-online";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        #endregion

        #region United Kingdom
        private async void Kingdom1(object sender, EventArgs e)
        {

            string url = "https://reporting.actionfraud.police.uk/login";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Kingdom2(object sender, EventArgs e)
        {

            string url = "https://www.nationalcrimeagency.gov.uk/what-we-do/crime-threats/fraud-and-economic-crime#:~:text=Report%20all%20incidents%20of%20fraud,In%20an%20emergency%2C%20call%20999.";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void Kingdom3(object sender, EventArgs e)
        {

            string url = "https://www.citizensadvice.org.uk/consumer/scams/reporting-a-scam/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

        #region USA
        private async void USA1(object sender, EventArgs e)
        {

            string url = "https://reportfraud.ftc.gov/#/";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void USA2(object sender, EventArgs e)
        {

            string url = "https://www.identitytheft.gov";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }

        private async void USA3(object sender, EventArgs e)
        {

            string url = "https://www.ic3.gov/Home/ComplaintChoice";

            await Launcher.OpenAsync(new Uri(url));

            //await Navigation.PushAsync(new WebviewPage(url));

        }
        #endregion

    }
}