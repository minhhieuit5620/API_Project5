using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class CategoryProject
    {
        public int IdCateProject { get; set; }
        public string NameCateProject { get; set; }
        public string DescriptionCateProject { get; set; }
        public string ImageCateProject { get; set; }
        public bool? Flag { get; set; }
    }
}
