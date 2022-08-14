using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Customers
    {
        public int IdCustomer { get; set; }
        public string NameCus { get; set; }
        public int? PhoneCus { get; set; }
        public string AddressCus { get; set; }
        public string EmailCus { get; set; }
        public bool? Gender { get; set; }
        public string Password { get; set; }
    }
}
