using ScamMobileApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{
    public class HelpCenterViewModel : BaseViewModel
    {
        private INavigation Navigation;

        private bool deatilNotVisible = true;
        public bool DeatilNotVisible
        {
            get => deatilNotVisible;
            set
            {
                deatilNotVisible = value;
                OnPropertyChanged(nameof(DeatilNotVisible));
            }
        }

        private bool deatilVisible = false;
        public bool DeatilVisible
        {
            get => deatilVisible;
            set
            {
                deatilVisible = value;
                OnPropertyChanged(nameof(DeatilVisible));
            }
        }


        
        public HelpCenterViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ShowDetailCommand = new Command(async () => await ShowDetailCommandExecute());
            ShowNoDetailCommand = new Command(async () => await ShowNoDetailCommandExecute());

        }

        public ICommand ShowDetailCommand { get; }

        private async Task ShowDetailCommandExecute()
        {
            try
            {
                DeatilNotVisible = true;
                DeatilVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public ICommand ShowNoDetailCommand { get; }

        private async Task ShowNoDetailCommandExecute()
        {
            try
            {
                DeatilNotVisible = false;
                DeatilVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
