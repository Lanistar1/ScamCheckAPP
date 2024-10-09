using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Others
{
    public class KeywordData
    {
        public List<string> keyword { get; set; }
    }

    public class GetUnwantedKeywordModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public KeywordData data { get; set; }
    }
}
