using ScamMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models
{
    public class MoreModel : BaseViewModel
    {
        public string Name { get; set; }
        public bool isSelected { get; set; }

        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
    }
}
