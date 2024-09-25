using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Experience
{

    public class ReportPostRequestModel 
    { 
        public string reasonReportedTitle { get; set; }
        public string reasonReportedBody { get; set; }
        public string experienceId { get; set; }
    }
}
