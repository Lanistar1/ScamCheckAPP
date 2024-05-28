using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{
    public class ScamViewModel : BindableObject
    {
        public ObservableCollection<Scam> Scams { get; set; }

        public ScamViewModel()
        {
            Scams = new ObservableCollection<Scam>
        {
            new Scam { Title = "Phishing Scams", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which..." },
            new Scam { Title = "Vishing Scams", FullDescription = "This type of scam involves sending emails or messages that appear to be from a legitimate source, such as a bank or government agency, in order to trick people into giving away their personal information. This type of scam involves sending emails or messages that appear to be from a legitimate source, such as a bank or government agency, in order to trick people into giving away their personal information. This type of scam involves..." },
            new Scam { Title = "Smishing Scams", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which..." },
            new Scam { Title = "Ransomware Scams", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which..." },
            new Scam { Title = "Investment Scams", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which..." }
        };
        }

        public ICommand ToggleDescriptionCommand => new Command<Scam>(ToggleDescription);

        private void ToggleDescription(Scam scam)
        {
            scam.IsExpanded = !scam.IsExpanded;
        }
    }
}
