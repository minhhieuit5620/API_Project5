using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Project5.Models;

namespace API_Project5.DTO
{
    public class HoaDon_DTO
    {
        public Orders hoaDon { get; set; }
        public OrderDetails[] chiTietHDs { get; set; }
        public Shipping Ship { get; set; }
    }
}
