using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Home
{
    public class DashboardViewModel : BaseViewModel
    {
        private INavigation Navigation;

        private ObservableCollection<DashboardModel> dashboard;
        public ObservableCollection<DashboardModel> Dashboard
        {
            get => dashboard;
            set
            {
                dashboard = value;
                OnPropertyChanged(nameof(Dashboard));
            }
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public DashboardViewModel(INavigation navigation)
        {
            Navigation = navigation;


            Dashboard = new ObservableCollection<DashboardModel>{
                new DashboardModel { ScamType = "Phishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Vishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Smishing scam check", Date = "04/08/2023"},
                new DashboardModel { ScamType = "Investment scam check", Date = "04/08/2023"},

             };

            Username = Global.UserData.username;
        }
    }
}
