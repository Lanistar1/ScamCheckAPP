using ScamMobileApp.Models.Experience;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using System.Linq;

namespace ScamMobileApp.ViewModels.Experience
{
    //public class ExperienceDetailViewModel : BaseViewModel
    //{
    //    public ExperienceDetailViewModel(INavigation navigation, ObservableCollection<ExperienceData> selectedItems)
    //    {
    //        Navigation = navigation;

    //        SelectedItems = selectedItems;


    //        UserExperienceData = new ObservableCollection<ExperienceData>(SelectedItems);

    //        FirstName = UserExperienceData.FirstOrDefault().userDetails.firstname;

    //    }


    //    #region Bindings

    //    public ObservableCollection<ExperienceData> selectedItems;
    //    public ObservableCollection<ExperienceData> SelectedItems
    //    {
    //        get => selectedItems;
    //        set
    //        {
    //            selectedItems = value;
    //        }
    //    }

    //    private ObservableCollection<ExperienceData> userExperienceData;
    //    public ObservableCollection<ExperienceData> UserExperienceData
    //    {
    //        get => userExperienceData;
    //        set
    //        {
    //            userExperienceData = value;
    //            OnPropertyChanged(nameof(UserExperienceData));
    //        }
    //    }
    //    private string firstName;
    //    public string FirstName
    //    {
    //        get => firstName;
    //        set
    //        {
    //            firstName = value;
    //            OnPropertyChanged(nameof(FirstName));
    //        }
    //    }

    //    private string productName;
    //    public string ProductName
    //    {
    //        get => productName;
    //        set
    //        {
    //            productName = value;
    //            OnPropertyChanged(nameof(ProductName));
    //        }
    //    }

    //    #endregion

    //    #region Commands

    //    #endregion


    //    #region functions, methods, events and Navigations


    //    #endregion


    //}

}
