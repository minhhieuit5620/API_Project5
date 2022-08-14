using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Projects
    {
        public int IdProject { get; set; }
        public string NameProject { get; set; }
        public string DescriptionProject { get; set; }
        public string AvatarProject { get; set; }
        public string ImageProject { get; set; }
        public int? PriceProject { get; set; }
        public bool? Flag { get; set; }
        public int? IdCategoryProject { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        public string Location { get; set; }
        public string NameCustomer { get; set; }
        public int? IdCustomer { get; set; }
    }
}
