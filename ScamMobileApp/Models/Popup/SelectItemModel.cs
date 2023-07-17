using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Popup
{
    public class SelectItemModel
    {
        public SelectItemModel(int id, string _value)
        {
            Id = id;
            Value = _value;
        }

        public int Id { get; set; }
        public string Value { get; set; }
    }
}
