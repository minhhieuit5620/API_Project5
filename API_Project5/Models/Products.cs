using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? IdCategory { get; set; }
    }
}
