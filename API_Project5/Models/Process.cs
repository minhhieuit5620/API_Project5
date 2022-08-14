using System;
using System.Collections.Generic;

namespace API_Project5.Models
{
    public partial class Process
    {
        public int Id { get; set; }
        public int? Step { get; set; }
        public string NameProcess { get; set; }
        public string Description { get; set; }
    }
}
