using ScamMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScamMobileApp.Models.ScamType
{
    public class ScamTypeData : BaseViewModel
    {
        public string ScamType { get; set; }
        public string ScamDetail { get; set; }
        public bool isSelected { get; set; }


        private string dishImage;
        public string DishImage
        {
            get { return dishImage; }
            set
            {
                dishImage = value;
                OnPropertyChanged(nameof(DishImage));
            }
        }
    }

    public class ScamTypeModel
    {
        public ObservableCollection<ScamTypeData> data;
    }
}
