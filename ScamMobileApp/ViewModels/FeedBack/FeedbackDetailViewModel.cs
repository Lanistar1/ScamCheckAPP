using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.FeedBack
{
    public class FeedbackDetailViewModel : BaseViewModel
    {
        public FeedbackDetailViewModel(INavigation navigation, ObservableCollection<GetFeedbackData> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            UserFeedbackData = new ObservableCollection<GetFeedbackData>(SelectedItems);

            FirstName = UserFeedbackData.FirstOrDefault().userDetails.firstname;
            //ProductName = ProductDetail.FirstOrDefault().name;


        }


        #region Bindings

        public ObservableCollection<GetFeedbackData> selectedItems;
        public ObservableCollection<GetFeedbackData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<GetFeedbackData> userFeedbackData;
        public ObservableCollection<GetFeedbackData> UserFeedbackData
        {
            get => userFeedbackData;
            set
            {
                userFeedbackData = value;
                OnPropertyChanged(nameof(UserFeedbackData));
            }
        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string productName;
        public string ProductName
        {
            get => productName;
            set
            {
                productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        #endregion

        #region Commands

        #endregion


        #region functions, methods, events and Navigations


        #endregion


    }

}
