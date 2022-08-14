using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class News
    {
        public int IdNew { get; set; }
        public string NameNew { get; set; }
        public string DescriptionNew { get; set; }
        public string AvaterNew { get; set; }
        public string ImageNew { get; set; }
        public int? IdCategoryNew { get; set; }
        public bool? Flag { get; set; }
    }
}
