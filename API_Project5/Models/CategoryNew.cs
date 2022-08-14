using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class CategoryNew
    {
        public int IdCategoryNew { get; set; }
        public string NameCategoryNew { get; set; }
        public string DescriptionCateNew { get; set; }
        public string ImageCateNew { get; set; }
        public bool? Flag { get; set; }
    }
}
