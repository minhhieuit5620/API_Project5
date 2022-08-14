using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class OrderDetails
    {
        public int IdOrderDetail { get; set; }
        public int? IdOrder { get; set; }
        public int? IdProduct { get; set; }
        public string NameProduct { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? SumMoney { get; set; }
        public string Note { get; set; }
    }
}
