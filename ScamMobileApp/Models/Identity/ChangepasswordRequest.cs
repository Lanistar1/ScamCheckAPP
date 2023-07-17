using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{
    public class ChangepasswordRequest
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }


}
