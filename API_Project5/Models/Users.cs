using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Users
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? DayStart { get; set; }
        public int? Rol { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
