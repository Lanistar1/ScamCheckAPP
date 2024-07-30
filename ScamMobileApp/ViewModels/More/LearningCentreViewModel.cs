using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{
    public class LearningCentreViewModel : BaseViewModel
    {
        //private INavigation Navigation;

        public ObservableCollection<Scam> Scams { get; set; }

        public LearningCentreViewModel(INavigation navigation)
        {
            Scams = new ObservableCollection<Scam>
            {
                new Scam { Title = "Is this a Scam?", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which can" },
                new Scam { Title = "How to remain vigilant always.", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which" },
                new Scam { Title = "How to spot a scammer", FullDescription = "Is there a scam which can cure crossdressing & bdsm compulsion? Is there a scam which" },
            
            };
        }

        public ICommand ToggleDescriptionCommand => new Command<Scam>(ToggleDescription);

        private void ToggleDescription(Scam scam)
        {
            scam.IsExpanded = !scam.IsExpanded;
        }
    }

}
