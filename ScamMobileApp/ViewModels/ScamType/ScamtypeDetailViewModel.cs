using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.ScamType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.ScamType
{
    public class ScamtypeDetailViewModel : BaseViewModel
    {
        public ScamtypeDetailViewModel(INavigation navigation, ObservableCollection<ScamTypeData> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;


            ScamtypeDetail = new ObservableCollection<ScamTypeData>(SelectedItems);

            //ProductName = ProductDetail.FirstOrDefault().name;


        }


        #region Bindings

        public ObservableCollection<ScamTypeData> selectedItems;
        public ObservableCollection<ScamTypeData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        private ObservableCollection<ScamTypeData> scamtypeDetail;
        public ObservableCollection<ScamTypeData> ScamtypeDetail
        {
            get => scamtypeDetail;
            set
            {
                scamtypeDetail = value;
                OnPropertyChanged(nameof(ScamtypeDetail));
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
