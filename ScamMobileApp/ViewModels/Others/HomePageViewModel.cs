using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.ViewModels.Others
{
    public class HomePageViewModel : BaseViewModel
    {
        public string CopyrightText => GetCopyrightText();

        public string GetCopyrightText()
        {
            int currentYear = DateTime.Now.Year;
            return $"© {currentYear} SCAMalicious";
        }
    }
}
