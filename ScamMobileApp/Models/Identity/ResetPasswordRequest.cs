using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{

    public class ResetPasswordRequest
    {
        public string code { get; set; }
        public string newPassword { get; set; }
    }


}
