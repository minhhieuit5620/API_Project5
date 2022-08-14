using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Shipping
    {
        public int ShipId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Note { get; set; }
        public string Payments { get; set; }
        public string NameOnCard { get; set; }
        public int? CardNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public int idOrder { get; set; }
        public string address { get; set; }
    }
}
