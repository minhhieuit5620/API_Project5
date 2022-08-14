using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public int? IdCustomer { get; set; }
        public string NameCus { get; set; }
        public DateTime? DayOrder { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
    }
}
