using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class LienHe
    {
        public int Id { get; set; }
        public string NameCus { get; set; }
        public string Email { get; set; }
        public string NoiDung { get; set; }
        public string Phone { get; set; }
        public DateTime? Date { get; set; }
    }
}
